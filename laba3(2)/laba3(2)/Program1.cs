using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3;
class Program1
{
    static void Main(string[] args)
    {
        Console.Write("f(x)=");
        Polynomial p1 = new Polynomial(new double[] { 4, 3, 2, 1 });
        p1.Print();
        Console.Write("Value: ");
        Console.WriteLine(p1.Calculate(2));
        Console.Write("g(x)=");
        Polynomial p2 = new Polynomial(new double[] { 2, 3, 4 });
        p2.Print();
        Console.Write("Value: ");
        Console.WriteLine(p2.Calculate(2));
        Console.Write("Sum: ");
        Polynomial p3 = p1.Add(p2);
        p3.Print();
        Console.Write("Diff: ");
        Polynomial p4 = p1.Sub(p2);
        p4.Print();
        Console.Write("Mult :");
        Polynomial p5 = p1.Mult(p2);
        p5.Print();
    }
}
