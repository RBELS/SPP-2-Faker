namespace Example;

public class Address
{
    public string Country;
    public string City;
    public string Street;
    public string HouseNo;

    public Address(string country, string city, string street, string houseNo)
    {
        Country = country;
        City = city;
        Street = street;
        HouseNo = houseNo;
    }
    
    public Address(string country, string city)
    {
        Country = country;
        City = city;
    }
}