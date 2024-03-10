namespace Faker.Generators;

public class IntGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(int);
    }

    public Type GetTargetType()
    {
        return typeof(int);
    }
}