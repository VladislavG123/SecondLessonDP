using System;


class Client
{
    public void Main()
    {
        Console.WriteLine("App: Launched with the ConcreteCreator1.");
        ClientCode(new ConcreteCreator1());

        Console.WriteLine("");

        Console.WriteLine("App: Launched with the ConcreteCreator2.");
        ClientCode(new ConcreteCreator2());
    }


    public void ClientCode(Creator creator)
    {
        // ...
        Console.WriteLine("Client: I'm not aware of the creator's class," +
            "but it still works.\n" + creator.SomeOperation());
        // ...
    }

}

public abstract class Creator
{
    // Deliver
    public abstract IProduct FactoryMethod();

    internal string SomeOperation()
    {
        // Вызываем фабричный метод, чтобы получить объект-продукт.
        IProduct product = FactoryMethod();
        // Далее, работаем с этим продуктом.
        string result = "Creator: The same creator's code has just worked with "
            + product.Operation();

        return result;
    }
}


public interface IProduct
{
    string Operation();
}

class ConcreteCreator2 : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct2();
    }
}

internal class ConcreteProduct2 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct2}";
    }
}

class ConcreteCreator1 : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}

internal class ConcreteProduct1 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct1}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
        Console.ReadLine();
    }
}




// Example console output
/*
App: Launched with the ConcreteCreator1.
Client: I'm not aware of the creator's class,but it still works.
Creator: The same creator's code has just worked with {Result of ConcreteProduct1}

App: Launched with the ConcreteCreator2.
Client: I'm not aware of the creator's class,but it still works.
Creator: The same creator's code has just worked with {Result of ConcreteProduct2}
 */
