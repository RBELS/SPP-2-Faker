namespace Faker.Generators;

public class LongGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.NextInt64();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(long);
    }

    public Type GetTargetType()
    {
        return typeof(long);
    }
}