namespace Example;

using Faker;

class Program
{
    static void Main(string[] args)
    {
        var faker = new Faker();
        var person = faker.Create<Person>();
        var book = faker.Create<Book>();
        Console.WriteLine("Done");
    }
}