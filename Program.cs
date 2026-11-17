
using System;

class Actor
{

    public string Name;
    public Actor(string name)
    {
        Name = name;
    }
    
    public void Event1Handler()
    {
        Console.WriteLine($"Актор {Name} гримується.");
    }

    public void Event2Handler()
    {
        Console.WriteLine($"Актор {Name} підготувався.");
    }

    public void Event3Handler()
    {
        Console.WriteLine($"Актор {Name} на сцену.");
    }
}

class Spectator
{
    public string Name;

    public Spectator(string name)
    {
        Name = name;
    }

    public void Event1Handler()
    {
        Console.WriteLine($"Глядач {Name} зайшов у театр.");
    }

    public void Event2Handler()
    {
        Console.WriteLine($"Глядач {Name} здає одяг у гардероб.");
    }

    public void Event3Handler()
    {
        Console.WriteLine($"Глядач {Name} зайшов до зали.");
    }
}

class Bell
{
    private int n;

    public delegate void BellEventHandler();

    public event BellEventHandler Event1;
    public event BellEventHandler Event2;
    public event BellEventHandler Event3;

    public Bell(int number)
    {
        n = number;
    }

    public void GenerateEvent1()
    {
        Console.WriteLine($"\nДзвінок {n}. Увага!!");
        Event1?.Invoke();
    }

    public void GenerateEvent2()
    {
        Console.WriteLine("\nДзвінок 2. Підготуватися!");
        Event2?.Invoke();
    }

    public void GenerateEvent3()
    {
        Console.WriteLine("\nДзвінок 3. Вистава починається.");
        Event3?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Actor actor = new Actor("Олександр");
        Spectator spectator = new Spectator("Марія");

        Bell bell1 = new Bell(1);

        bell1.Event1 += actor.Event1Handler;
        bell1.Event1 += spectator.Event1Handler;

        bell1.GenerateEvent1();

        Bell bell2 = new Bell(2);

        bell2.Event2 += actor.Event2Handler;
        bell2.Event2 += spectator.Event2Handler;

        bell2.GenerateEvent2();

        Bell bell3 = new Bell(3);

        bell3.Event3 += actor.Event3Handler;
        bell3.Event3 += spectator.Event3Handler;

        bell3.GenerateEvent3();

        Console.WriteLine("\nВистава розпочалася!");
    }
}
