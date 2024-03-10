namespace Faker.Generators;

public class DecimalGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (decimal)context.Random.NextDouble();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(decimal);
    }

    public Type GetTargetType()
    {
        return typeof(decimal);
    }
}