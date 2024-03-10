namespace Faker.Generators;

public class ULongGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (ulong) context.Random.NextInt64();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(ulong);
    }

    public Type GetTargetType()
    {
        return typeof(ulong);
    }
}