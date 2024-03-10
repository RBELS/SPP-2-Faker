namespace Faker.Generators;

public class ByteGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (byte)context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(byte);
    }

    public Type GetTargetType()
    {
        return typeof(byte);
    }
}