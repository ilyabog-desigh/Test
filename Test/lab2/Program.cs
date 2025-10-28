using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        TextWriter save_out = Console.Out;
        TextReader save_in = Console.In;

        using (var new_out = new StreamWriter(@"output.txt"))
        using (var new_in = new StreamReader(@"input.txt"))
        {
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            
            double a1 = Convert.ToDouble(Console.ReadLine());
            double a2 = Convert.ToDouble(Console.ReadLine());
            double a3 = Convert.ToDouble(Console.ReadLine());
            double a4 = Convert.ToDouble(Console.ReadLine());
            double a5 = Convert.ToDouble(Console.ReadLine());

           
            if (a1 < 0  || a2 < 0 || a3 < 0 || a4 < 0  || a5 < 0 )
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                
                double s = CalculateS(a1, a2, a3, a4, a5);

                
                double k = CalculateK(a1, a2, a3, a4, a5);

                if (double.IsNaN(s) || double.IsInfinity(s) ||
                    double.IsNaN(k) || double.IsInfinity(k))
                {
                    Console.WriteLine("ERROR");
                }
                else
                {
                    Console.WriteLine(String.Format("{0:0.000}", s));
                    Console.WriteLine(String.Format("{0:0.000}", k));
                }
            }
        }

        
        Console.SetOut(save_out);
        Console.SetIn(save_in);
    }

    static double CalculateS(double a1, double a2, double a3, double a4, double a5)
    {
        
        if (a1 + a2 < 0)
        {
            return double.NaN; 
        }

        if (a3 - a4 == 0)
        {
            return double.NaN; 
        }

        double numerator = Math.Sqrt(a1 + a2);
        double denominator = a3 - a4;

        return numerator / denominator * a5;
    }

    static double CalculateK(double a1, double a2, double a3, double a4, double a5)
    {
        
        if (a3 * a4 * a5 < 0)
        {
            return double.NaN; 
        }

        if (a3 * a4 * a5 == 0)
        {
            return double.NaN; 
        }

        double numerator = a1 * a2;
        double denominator = Math.Sqrt(a3 * a4 * a5);

        if (denominator == 0)
        {
            return double.NaN; 
        }

        return numerator / denominator;
    }
}