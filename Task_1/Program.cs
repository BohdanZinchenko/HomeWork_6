using System;
using System.Diagnostics;
using System.Linq;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program with use Linq and PLinq ");
            Console.WriteLine("Student of Pm Academy Zinchenko Bohdan");
            while (true)
            {
                int toNum;
                int fromNum;

                while (true)
                {
                    Console.Write("Input number should start  ");
                    if (!int.TryParse(Console.ReadLine(), out fromNum))
                    {
                        Console.WriteLine("Error input");
                        continue;
                    }
                    Console.Write("Input number should start  ");
                    if (!int.TryParse(Console.ReadLine(), out toNum))
                    {
                        Console.WriteLine("Error input");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("Choose what kind of Linq you want to use");
                Console.WriteLine("1 : Linq");
                Console.WriteLine("2 : PLinq");
                Console.WriteLine("3 : Exit");
                if (!int.TryParse(Console.ReadLine(), out var choose) || choose > 3 || choose < 0)
                {
                    Console.WriteLine("Error input");
                    continue;
                }

                switch (choose)
                {
                    case 1:
                        Linq(fromNum, toNum);
                        break;
                    case 2:
                        PLinq(fromNum, toNum);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Choose from 1 to 3");
                        break;
                }

            }
        }

        public static void PLinq(int fromNum, int toNum)
        {
            if (fromNum < 0)
            {
                fromNum = 0;
            }

            if (toNum < 0)
            {
                toNum = 0;
            }
            static bool IsDivided(int num, int divisor) => (num % divisor).Equals(0);
            var watchForPLinq = new Stopwatch();
            watchForPLinq.Restart();

            var numbersPLinq = Enumerable.Range(fromNum, toNum).AsParallel().Where(num =>
                    Enumerable.Range(2, (int)Math.Ceiling(Math.Sqrt(num)))
                        .Any(div => !num.Equals(div) && IsDivided(num, div)));

            var primaryPLinq = Enumerable.Range(fromNum, toNum).AsParallel().Except(numbersPLinq);

            Console.WriteLine($" PLinq Items = {primaryPLinq.Count()}");
            watchForPLinq.Stop();
            Console.WriteLine($" Time PLinq = {watchForPLinq.Elapsed}");


        }

        public static void Linq(int fromNum, int toNum)
        {
            if (fromNum < 0)
            {
                fromNum = 0;
            }

            if (toNum < 0)
            {
                toNum = 0;
            }
            static bool IsDivided(int num, int divisor) => (num % divisor).Equals(0);
            var watchForLinq = new Stopwatch();
            watchForLinq.Restart();

            var numbersLinq = Enumerable.Range(fromNum, toNum).Where(num =>
                Enumerable.Range(2, (int)Math.Ceiling(Math.Sqrt(num)))
                    .Any(div => !num.Equals(div) && IsDivided(num, div)));

            var primary = Enumerable.Range(fromNum, toNum).Except(numbersLinq);

            Console.WriteLine($" Linq Items = {primary.Count()}");
            watchForLinq.Stop();
            Console.WriteLine($" Time Linq = {watchForLinq.Elapsed}");
        }
    }
}
