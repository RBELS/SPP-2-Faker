using System.Text;

namespace Faker.Generators;

public class StringGenerator : IValueGenerator
{
    private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public object Generate(GeneratorContext context)
    {
        var length = context.Random.Next(1, 10);
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[context.Random.Next(0, chars.Length)]);
        }
        
        return stringBuilder.ToString();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(string);
    }

    public Type GetTargetType()
    {
        return typeof(string);
    }
}

// public class StringGenerator : IValueGenerator
// {
//     public object Generate(GeneratorContext context)
//     {
//         int length = context.Random.Next(1, 10);
//         const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
//         return new string(Enumerable.Repeat(chars, length)
//             .Select(s => s[context.Random.Next(s.Length)]).ToArray());
//     }
//
//     public bool CanGenerate(Type type)
//     {
//         return type == typeof(string);
//     }
//
//     public Type GetTargetType()
//     {
//         return typeof(string);
//     }
// }