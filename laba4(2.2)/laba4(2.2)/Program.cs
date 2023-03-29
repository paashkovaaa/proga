//Порт.Визначити ієрархію суден.
//Створити перевізника, один перевізник може мати кілька кораблів. +
//Порахувати загальну місткість і вантажність.+
//Провести сортування суден за кількістю затраченого палива за годину.+
//Знайти судно, що відповідає заданому діапазону параметра року випуску.


class Port
{
    
    public static void Main(string[] args)
    {
        var ship1 = new Ship("ship1",10, 10, 10, 1954);
        var ship2 = new Ship("ship2",12, 10, 15, 1968);
        var ship3 = new Ship("ship3",15, 10, 7, 1990);
        
        var transporter = new Transporter("transporter1");
        transporter.Add(ship1);
        transporter.Add(ship2);
        transporter.Add(ship3);
        Console.WriteLine(transporter);
        transporter.SortByConsumption();
        Console.WriteLine("Sorted by consumption: \n"+ transporter);
        var shipByYear = transporter.FindByYear(1965, 2000);
        Console.WriteLine("Ship by year: \n"+ shipByYear);
    }
}
class Transporter
{
    private List<Ship> Ships = new();

    private string name;

    public Transporter(string name)
    {
        this.name = name;
    }

    public void Add(Ship ship)
    {
        Ships.Add(ship);
    }

    public override string ToString()
    {
        return $"Name: {name}, TotalCapacity: {TotalCapacity()}, TotalPayload: {TotalPayload()}, Ships:\n" + String.Join(",\n" , Ships);
    }

    public int TotalCapacity()
    {
        return Ships.Select(ship => ship.Capacity).Sum();
    }
    public int TotalPayload()
    {
        return Ships.Select(ship => ship.Payload).Sum();
    }

    public static int CompareByConsumption(Ship ship1, Ship ship2)
    {
        return ship2.Consumption - ship1.Consumption;
    }
    public void SortByConsumption()
    {
        Ships.Sort(CompareByConsumption);
    }

    public Ship FindByYear(int year1, int year2)
    {
        return Ships.First(ship => ship.Year >= year1 && ship.Year <= year2);
    }
    
}

class Ship
{
    public override string ToString()
    {
        return $"Ship: Name: {name}, Capacity: {capacity}, Payload: {payload}, Consumption: {consumption}, Year: {year}";
    }

    public Ship(string name, int capacity, int payload, int consumption, int year)
    {
        this.name = name;
        this.capacity = capacity;
        this.payload = payload;
        this.consumption = consumption;
        this.year = year;
    }

    public int Capacity => capacity;

    public int Payload => payload;

    public int Consumption => consumption;

    public int Year => year;

    private string name;
    private int capacity;
    private int payload;
    private int consumption;
    private int year;
}



