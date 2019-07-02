using System;


class Client
{
    public void Main()
    {
        Console.WriteLine("App: Launched with the crossbow.");
        ClientCode(new Сrossbow());

        Console.WriteLine("");

        Console.WriteLine("App: Launched with the Shotgun.");
        ClientCode(new Shotgun());
    }


    public void ClientCode(Weapon gun)
    {
        Console.WriteLine($"{gun.GetName()} " + gun.Shoot());
    }

}

public abstract class Weapon
{
    public abstract IBullet GetBullet();

    public abstract string GetName();

    public string Shoot()
    {
        // Вызываем фабричный метод, чтобы получить объект-продукт.
        IBullet bullet = GetBullet();
        // Далее, работаем с этим продуктом.
        string result = "shooted with "
            + bullet.GetName();

        return result;
    }
}


public interface IBullet
{
    string GetName();
}

class Shotgun : Weapon
{
    public override IBullet GetBullet()
    {
        return new ShotgunBullet();
    }

    public override string GetName()
    {
        return "Shotgun";
    }
}

internal class ShotgunBullet : IBullet
{
    public string GetName()
    {
        return "ShotgunBullet";
    }
}

class Сrossbow : Weapon
{
    public override IBullet GetBullet()
    {
        return new СrossbowArrow();
    }

    public override string GetName()
    {
        return "Сrossbow";
    }
}

internal class СrossbowArrow : IBullet
{
    public string GetName()
    {
        return "СrossbowArrow";
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


