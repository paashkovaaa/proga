//Створити суперклас Птах 
//і підкласи Орел, Папуга, Нелетючий птах, Страус, Пінгвін. 
//Подумати, які з вищенаведених підкласів також можуть бути суперкласами.  
//За допомогою конструктора задати вік кожного птаха. 
//Визначити максимальну висоту польоту летючих птахів та швидкість бігу нелетючих.

class Bird
{
    private int age;

    public int Age => age;
    public Bird(int age)
    {
        this.age = age;
    }
}

class Eagle : FlightBird
{
    public Eagle(int age) : base(age, 1000)
    {
        
    }
}
class Parrot : FlightBird
{
    public Parrot(int age) : base(age, 500)
    {
    }
}

class FlightBird : Bird
{
    private int maxHeight;

    public int MaxHeight => maxHeight;

    public FlightBird(int age, int maxHeight) : base(age)
    {
        this.maxHeight = maxHeight;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} age: {Age}, {nameof(maxHeight)}: {maxHeight}";
    }
}

class FlightlessBird : Bird
{
    private int maxSpeed;

    public int MaxSpeed => maxSpeed;

    public FlightlessBird(int age, int maxSpeed) : base(age)
    {
        this.maxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} age: {Age}, {nameof(maxSpeed)}: {maxSpeed}";
    }
}

class Ostrich : FlightlessBird
{
    public Ostrich(int age) : base(age, 150)
    {
    }
}

class Penguin : FlightlessBird
{
    public Penguin(int age) : base(age, 20)
    {
    }
}


class Program
{
    public static void Main(string[] args)
    {
        Bird[] birds = { new Eagle(10), new Parrot(3), new Ostrich(15), new Penguin(5) };
        foreach (var bird in birds)
        {
            Console.WriteLine(bird);
        }
        var maxSpeed = birds.Max(bird =>
        {
            if (bird is FlightlessBird)
            {
                return ((FlightlessBird)bird).MaxSpeed;
            }
            else
            {
                return 0;

            }
        });
        Console.WriteLine("maxSpeed:"+maxSpeed);

        var maxHeight = birds.Max(bird =>
        {
            if (bird is FlightBird)
            {
                return ((FlightBird)bird).MaxHeight;
            }
            else
            {
                return 0;

            }
        });
        Console.WriteLine("maxHeight:"+maxHeight);
    }
}