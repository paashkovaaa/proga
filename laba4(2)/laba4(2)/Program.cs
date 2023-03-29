namespace laba4;
class Program
{
    public static void Main(string[] args)
    {
        Date date = new Date(03, 08);
        date.Print();
        date.PrintWeekDay();

        Console.WriteLine(Date.getInterval(new Date(03, 08), new Date(03, 12)));
        Console.WriteLine(Date.getInterval(new Date(03, 08), new Date(03, 5)));
        Console.WriteLine(Date.getInterval(new Date(12, 08), new Date(11, 05)));
    }

}
