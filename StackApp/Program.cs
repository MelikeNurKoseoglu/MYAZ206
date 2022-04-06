using System;
using System.Collections.Generic;

namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Selam";
            var stack = new DataStructures.Array.Stack.ArrayStack<char>();


            for (int i = 0; i < message.Length; i++)
            {
                stack.Push(message[i]);
            }
            var n = stack.Count;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(stack.Pop());
            }
           

            Console.ReadKey();
        }
    }
}
