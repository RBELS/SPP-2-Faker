namespace Faker.Generators;

public class ShortGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (short) context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(short);
    }

    public Type GetTargetType()
    {
        return typeof(short);
    }
}