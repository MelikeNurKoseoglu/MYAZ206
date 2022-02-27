using System;

namespace VYLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{byte.MinValue} " +
                $"- {byte.MaxValue}");
            Console.WriteLine("*****");
            Console.WriteLine($"{sbyte.MinValue} " +
                $"- {sbyte.MaxValue}");
            Console.WriteLine("*****");
            Console.WriteLine($"{Int16.MinValue} " +
                $"- {Int16.MaxValue}");
            Console.WriteLine("*****");
            Console.WriteLine($"{UInt16.MinValue} " +
                $"- {UInt16.MaxValue}");
            Console.WriteLine("*****");
            Console.WriteLine($"{Int32.MinValue} " +
                $"- {Int32.MaxValue}");
            Console.WriteLine("*****");
            Console.WriteLine($"{Int64.MinValue}" +
                $" - {Int64.MaxValue}");


            Console.ReadKey();
        }
    }
}
