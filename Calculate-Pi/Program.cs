using System;

namespace Calculate_Pi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Started");
            Console.WriteLine();

            Console.WriteLine("Nilakantha");
            Console.WriteLine($"PI => {CalculatePiNilakantha(3100)}");

            Console.WriteLine("Gregory-Leibniz");
            Console.WriteLine($"PI => {CalculatePiGregoryLeibniza(20000000)}");

            Console.WriteLine("With Limits");
            Console.WriteLine($"PI => {CalculatePiWithLimits(10000000000)}");

            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        private static decimal CalculatePiNilakantha(int iterations)
        {
            // π = 3 + 4/(2*3*4) - 4/(4*5*6) + 4/(6*7*8) - 4/(8*9*10) + 4/(10*11*12) - 4/(12*13*14) + 4/(14*15*16) - 4/(16*17*18) ... 

            decimal pi = 3;
            bool step = true;

            for (int i = 2; i < iterations; i += 2)
            {
                decimal parcial = 4M / ((i) * (i + 1) * (i + 2));
                pi += (step == true ? parcial : -parcial);
                step = !step;
            }

            return pi;
        }

        private static decimal CalculatePiGregoryLeibniza(int iterations)
        {
            // π = (4/1) - (4/3) + (4/5) - (4/7) + (4/9) - (4/11) + (4/13) - (4/15) + (4/17) - (4/19) ...

            decimal pi = 0;
            bool step = true;

            for (int i = 1; i < iterations; i += 2)
            {
                decimal parcial = 4M / i;
                pi += (step == true ? parcial : -parcial);
                step = !step;
            }

            return pi;
        }

        private static double CalculatePiWithLimits(double value)
        {
            // π = x * sen(180 / x)

            var degrees = value * (Math.Sin(180.0 / value));

            // Angle in degrees to Radians
            return (Math.PI / 180.0) * degrees;
        }

    }

}