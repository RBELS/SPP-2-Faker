namespace Faker.Generators;

public class BoolGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.Next(0, 2) == 0;
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(bool);
    }

    public Type GetTargetType()
    {
        return typeof(bool);
    }
}