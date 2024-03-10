namespace Faker.Generators;

public class DateTimeGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return new DateTime((context.Random.NextInt64() % (DateTime.MaxValue.Ticks - DateTime.MinValue.Ticks) + DateTime.MinValue.Ticks));
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(DateTime);
    }

    public Type GetTargetType()
    {
        return typeof(DateTime);
    }
}