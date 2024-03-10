namespace Faker.Generators;

public class FloatGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.NextSingle();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(float);
    }

    public Type GetTargetType()
    {
        return typeof(float);
    }
}