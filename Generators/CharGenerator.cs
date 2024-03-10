namespace Faker.Generators;

public class CharGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (char) context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(char);
    }

    public Type GetTargetType()
    {
        return typeof(char);
    }
}