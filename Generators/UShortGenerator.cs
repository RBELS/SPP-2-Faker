namespace Faker.Generators;

public class UShortGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (ushort)context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(ushort);
    }

    public Type GetTargetType()
    {
        return typeof(ushort);
    }
}