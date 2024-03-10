namespace Faker.Generators;

public class SByteGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (sbyte) context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(sbyte);
    }

    public Type GetTargetType()
    {
        return typeof(sbyte);
    }
}