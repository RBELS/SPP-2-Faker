namespace FakerTests;

using Faker;
using Example;

public class Tests
{
    [Test]
    public void TestGeneratePlain()
    {
        var faker = new Faker();
        var person = faker.Create<Person>();
        Assert.Multiple(() =>
        {
            Assert.That(person.FirstName, Is.Not.Null);
            Assert.That(person.MiddleName, Is.Not.Null);
            Assert.That(person.LastName, Is.Not.Null);
            Assert.That(person.DateOfBirth, Is.Not.EqualTo(DateTime.MinValue));
            
            Assert.That(person.Address.Country, Is.Not.Null);
            Assert.That(person.Address.City, Is.Not.Null);
            Assert.That(person.Address.Street, Is.Not.Null);
            Assert.That(person.Address.HouseNo, Is.Not.Null);
            
            Assert.That(person.MusicList, Is.Not.Empty);
        });
    }
    
    [Test]
    public void TestGenerateRecursive()
    {
        var faker = new Faker();
        var book = faker.Create<Book>();
        Assert.Multiple(() =>
        {
            Assert.That(book.Name, Is.Not.Null);
            Assert.That(book.YearReleased, Is.Not.EqualTo(int.MinValue));
            Assert.That(book.Price, Is.Not.EqualTo(double.MinValue));
            Assert.That(book.Author, Is.Not.Null);
            
            Assert.That(book.Author.FirstName, Is.Not.Null);
            Assert.That(book.Author.LastName, Is.Not.Null);
            Assert.That(book.Author.Age, Is.Not.EqualTo(int.MinValue));
            
            Assert.That(book == book.Author.Book, Is.True);
        });
    }
    
    [Test]
    public void TestPrivateFields()
    {
        var faker = new Faker();
        var human = faker.Create<Human>();
        
        Assert.Multiple(() =>
        {
            Assert.That(human.getName(), Is.Not.Null);
            Assert.That(human.getWeight(), Is.Not.EqualTo(int.MinValue));
            Assert.That(human.getAge(), Is.Not.EqualTo(int.MinValue));
        });
    }
}