namespace Faker.Generators;

public class UIntGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (uint)context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(uint);
    }

    public Type GetTargetType()
    {
        return typeof(uint);
    }
}