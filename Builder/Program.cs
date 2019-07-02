using System;
using System.Collections.Generic;

public interface IBuilder
{
    void BuildBody();

    void BuildBatteryPlus();

    void BuildCover();
}

public class Samsung : IBuilder
{
    private Complectation _complectation = new Complectation();

    public Samsung()
    {
        Reset();
    }

    public void Reset()
    {
        _complectation = new Complectation();
    }

    public void BuildBody()
    {
        _complectation.Add("SamsungBody");
    }

    public void BuildBatteryPlus()
    {
        _complectation.Add("SamsungBatteryPlus");
    }

    public void BuildCover()
    {
        _complectation.Add("SamsungCover");
    }

    public Complectation GetComplectation()
    {
        Complectation result = _complectation;

        Reset();

        return result;
    }

}


public class Nokia : IBuilder
{
    private Complectation _complectation = new Complectation();

    public Nokia()
    {
        Reset();
    }

    public void Reset()
    {
        _complectation = new Complectation();
    }

    public void BuildBody()
    {
        _complectation.Add("NokiaBody");
    }

    public void BuildBatteryPlus()
    {
        _complectation.Add("NokiaBatteryPlus");
    }

    public void BuildCover()
    {
        _complectation.Add("NokiaCover");
    }

    public Complectation GetComplectation()
    {
        Complectation result = _complectation;

        Reset();

        return result;
    }

}


public class Complectation
{
    private List<object> _parts = new List<object>();

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public string ListParts()
    {
        string str = string.Empty;

        for (int i = 0; i < _parts.Count; i++)
        {
            str += _parts[i] + ", ";
        }

        str = str.Remove(str.Length - 2);

        return "Product parts: " + str + "\n";
    }
}

public class Director
{
    private IBuilder _builder;

    public IBuilder Builder
    {
        set { _builder = value; }
    }

    public void Basic()
    {
        _builder.BuildBody();
    }

    internal void Standart()
    {
        _builder.BuildBody();
        _builder.BuildBatteryPlus();
    }

    internal void Lux()
    {
        _builder.BuildBody();
        _builder.BuildBatteryPlus();
        _builder.BuildCover();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Director director = new Director();

        Samsung samsung = new Samsung();
        director.Builder = samsung;

        Console.WriteLine("Basic samsung complectation:\n");
        director.Basic();
        Console.WriteLine(samsung.GetComplectation().ListParts());

        Console.WriteLine("Standard samsung complectation:\n");
        director.Standart();
        Console.WriteLine(samsung.GetComplectation().ListParts());

        Console.WriteLine("Lux samsung complectation:\n");
        director.Lux();
        Console.WriteLine(samsung.GetComplectation().ListParts());

        Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-\n");

        Nokia nokia = new Nokia();
        director.Builder = nokia;

        Console.WriteLine("Basic nokia complectation:\n");
        director.Basic();
        Console.WriteLine(nokia.GetComplectation().ListParts());

        Console.WriteLine("Standard nokia complectation:\n");
        director.Standart();
        Console.WriteLine(nokia.GetComplectation().ListParts());

        Console.WriteLine("Lux nokia complectation:\n");
        director.Lux();
        Console.WriteLine(nokia.GetComplectation().ListParts());



        Console.ReadLine();
    }
}
