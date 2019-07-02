// TODO: привести логику работы программы в сооветствии с выводом в консоль приведенным внизу файла

using System;

public class Person
{
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Name { get; set; }
    public IdInfo IdInfo { get; set; }

    public string SecondName { get; set; }
    public Address Address { get; set; }

    public Person ShallowCopy()
    {
        return (Person)MemberwiseClone();
    }

    public Person DeepCopy()
    {
        Person clone = (Person)MemberwiseClone();
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);
        clone.Name = String.Copy(Name);
        clone.SecondName = String.Copy(SecondName);
        clone.Address = Address.DeepCopy();
        clone.Age = Age;
        clone.BirthDate = BirthDate;
        return clone;
    }
}

public class IdInfo
{
    public int IdNumber;

    public IdInfo(int idNumber)
    {
        IdNumber = idNumber;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person firstPerson = new Person
        {
            Age = 42,
            BirthDate = Convert.ToDateTime("1977-01-01"),
            Name = "Jack",
            SecondName = "Daniels",
            IdInfo = new IdInfo(666),
            Address = new Address("Kings Road", 15)
        };

        Person secondPerson = firstPerson.ShallowCopy();
        Person thirdPerson = firstPerson.DeepCopy();

        Console.WriteLine("Original values of p1, p2, p3:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(firstPerson);
        Console.WriteLine("   p2 instance values:");
        DisplayValues(secondPerson);
        Console.WriteLine("   p3 instance values:");
        DisplayValues(thirdPerson);

        firstPerson.Age = 32;
        firstPerson.BirthDate = Convert.ToDateTime("1900-01-01");
        firstPerson.Name = "Frank";
        firstPerson.SecondName = "Simpson";
        firstPerson.IdInfo.IdNumber = 7878;
        firstPerson.Address = new Address("Wall street", 10);
        Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(firstPerson);
        Console.WriteLine("   p2 instance values (reference values have changed):");
        DisplayValues(secondPerson);
        Console.WriteLine("   p3 instance values (everything was kept the same):");
        DisplayValues(thirdPerson);

        Console.Read();
    }

    public static void DisplayValues(Person person)
    {
        Console.WriteLine($"      Name: {person.Name}, Second name: {person.SecondName}, Age: {person.Age}, BirthDate: {person.BirthDate.ToString("dd/MM/yyyy")}");
        Console.WriteLine("      ID#: {0:d}", person.IdInfo.IdNumber);
        Console.WriteLine($"      Full Address: {person.Address.ToString()}");
    }
}

public class Address
{
    private string _street;
    private int _house;

    public Address(string street, int home)
    {
        _street = street;
        _house = home;
    }

    public override string ToString()
    {
        return $"{_street} {_house}";
    }

    public Address ShallowCopy()
    {
        return (Address)MemberwiseClone();
    }

    public Address DeepCopy()
    {
        Address clone = (Address)MemberwiseClone();
        clone._house = _house;
        clone._street = String.Copy(_street);
        return clone;
    }

}


/*
Original values of p1, p2, p3:
   p1 instance values:
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road
   p2 instance values:
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road
   p3 instance values:
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road

Values of p1, p2 and p3 after changes to p1:
   p1 instance values:
      Name: Frank, Second Name: Simpson, Age: 32, BirthDate: 01/01/00
      ID#: 7878
      Full Address: 10 Wall street
   p2 instance values (reference values have changed):
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 7878
      Full Address: 10 Wall street
   p3 instance values (everything was kept the same):
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road
 */
