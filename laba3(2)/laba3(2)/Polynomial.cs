//Скласти опис класу многочленів від однієї змінної,+
//що задаються ступенем многочлена і масивом коефіцієнтів.+
//Передбачити методи для обчислення значення многочлена для заданого аргументу +
//, операції додавання +
//, віднімання +
//і множення многочленів з отриманням нового об'єкта-многочлена +
//, висновок на екран опису многочлена. +

namespace laba3;
internal class Polynomial
{  
    private double[] coefficients;
    public Polynomial(double[] coefficients)
    {
        this.coefficients = coefficients;
    }
    public double Calculate(double x)
    {
        int power = coefficients.Length - 1;
        double result = 0;
        for (int i = 0; i < coefficients.Length; i++)
        {
            result += coefficients[i] * Math.Pow(x,power--);

        }
        return result;
    }
    public Polynomial Add(Polynomial p2)
    { 
        int length = coefficients.Length;
        if (p2.coefficients.Length > length) 
        {
            length = p2.coefficients.Length;
        }

        double[] coeffSum = new double[length];

        int i1 = coefficients.Length - 1;
        int i2 = p2.coefficients.Length - 1;

        for (int i3 = coeffSum.Length - 1; i3 >= 0; i3--) 
        {

            if (i1 >= 0) {
                coeffSum[i3] = coeffSum[i3] + this.coefficients[i1--];
            }
            if (i2 >= 0)
            {
                coeffSum[i3] = coeffSum[i3] + p2.coefficients[i2--];
            }
        }
        return new Polynomial(coeffSum);
    }
    public Polynomial Sub(Polynomial p2)
    {
        int lenght = coefficients.Length;
        if (p2.coefficients.Length > lenght)
        {
            lenght = p2.coefficients.Length;
        }

        double[] coeffSub = new double[lenght];

        int i1 = coefficients.Length - 1;
        int i2 = p2.coefficients.Length - 1;
        for (int i3 = coeffSub.Length - 1; i3 >= 0; i3--)
        {
            if (i1 >= 0)
            {
                coeffSub[i3] = coeffSub[i3] + this.coefficients[i1--];
            }
            if (i2 >= 0)
            {
                coeffSub[i3] = coeffSub[i3] - p2.coefficients[i2--];
            }
        }
        return new Polynomial(coeffSub);
    }
    public Polynomial Mult(Polynomial p2)
    {
        double[] coeffMult = new double[coefficients.Length + p2.coefficients.Length - 1];

        for (int i = 0; i < coefficients.Length; i++)
        {
            for (int j = 0; j < p2.coefficients.Length; j++)
            {
                coeffMult[i + j] += coefficients[i] * p2.coefficients[j];
            }
        }

        return new Polynomial(coeffMult);
    }
    public void Print()
    {
        //Console.Write("f(x)=");
        int power = coefficients.Length-1;
        for (int i = 0; i < coefficients.Length; i++)
        {
            Console.Write(coefficients[i]);
            if (power >= 1)
            {
                Console.Write("x"+"^" + power--);
            }
            if (i < coefficients.Length - 1 && coefficients[i + 1] >= 0) { 
                Console.Write('+');
            }
          
        }
        Console.WriteLine();
    }
}

