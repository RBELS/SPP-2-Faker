namespace Example;

public class Person
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }

    public DateTime DateOfBirth { get; set; }
    public List<string> MusicList { get; set; } 
}