using System.Collections;
using System.Reflection;
using Faker.Generators;

namespace Faker;

public class Faker
{
    private GeneratorContext _context;
    private readonly IDictionary<Type, IValueGenerator> _generators;

    public Faker()
    {
        this._context = new GeneratorContext();
        this._generators = new Dictionary<Type, IValueGenerator>();
        
        var targetNamespace = "Faker.Generators";
        var assembly = Assembly.GetExecutingAssembly(); // Get the current assembly

        var types = assembly.GetTypes()
            .Where(t => t.Namespace == targetNamespace && t.IsClass)
            .ToArray();

        foreach (var type in types)
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);
            var generator = (IValueGenerator) constructor.Invoke(null);
            _generators.Add(generator.GetTargetType(), generator);
        }
    }

    public void ClearContext()
    {
        this._context = new GeneratorContext();
    }
    
    public T Create<T>()
    {
        return (T) Create(typeof(T));
    }
    
    private object Create(Type type)
    {
        if (type.IsValueType || type == typeof(string))
        {
            return GenerateRandomValue(type);
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        {
            var subType = type.GetGenericArguments()[0];
            var listType = typeof(List<>).MakeGenericType(subType);
            
            var list = (IList) Activator.CreateInstance(listType)!;
            var count = new Random().Next() % 10;
            for (int i = 0; i < count; i++)
            {
                list.Add(Create(subType));
            }
            return list;
        }

        if (_context.GetGeneratedInstance(type) != null)
        {
            return _context.GetGeneratedInstance(type);
        }

        var constructor = type.GetConstructor(Type.EmptyTypes);
        if (constructor == null)
        {
            var constructors = type.GetConstructors();
            Array.Sort(constructors, (a, b) => b.GetParameters().Length - a.GetParameters().Length);
            constructor = constructors[0];
            
            var args = new List<object>();
            
            foreach (var parameterInfo in constructor.GetParameters())
            {
                args.Add(Create(parameterInfo.ParameterType));
            }

            var instance = constructor.Invoke(args.ToArray());
            _context.StoreGeneratedInstance(type, instance);
            FillPropertiesAndFields(instance);
            return instance;
        }
        
        if (constructor != null)
        {
            var instance = constructor.Invoke(null);
            _context.StoreGeneratedInstance(type, instance);
            FillPropertiesAndFields(instance);
            return instance;
        }
        
        // no deafult constructor
        throw new InvalidOperationException($"Тип {type.FullName} не имеет конструктора по умолчанию.");
    }
    
    private void FillPropertiesAndFields(object instance)
    {
        var type = instance.GetType();

        foreach (var field in type.GetFields())
        {
            if ((field.FieldType == type || field.FieldType.IsAssignableFrom(type))) //???
            {
                field.SetValue(instance, Create(field.FieldType));
            }
        }

        foreach (var property in type.GetProperties())
        {
            if (property.CanWrite)
            {
                property.SetValue(instance, Create(property.PropertyType));
            }
        }
    }
    
    private object GenerateRandomValue(Type type)
    {
        IValueGenerator generator;
        if (_generators.TryGetValue(type, out generator))
        {
            return generator.Generate(_context);
        }
        throw new NotSupportedException($"Генерация случайных значений для типа {type.FullName} не поддерживается.");
    }
}