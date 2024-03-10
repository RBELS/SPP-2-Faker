namespace Faker.Generators;

public class DoubleGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.NextDouble();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(double);
    }

    public Type GetTargetType()
    {
        return typeof(double);
    }
}