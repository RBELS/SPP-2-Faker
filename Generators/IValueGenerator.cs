namespace Faker.Generators;

public interface IValueGenerator
{
    object Generate(GeneratorContext context);
    bool CanGenerate(Type type);
    Type GetTargetType();
}