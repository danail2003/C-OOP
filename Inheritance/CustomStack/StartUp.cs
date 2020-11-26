using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Stack<string> names = new Stack<string>();
            names.Push("Gosho");
            names.Push("Pesho");
            names.Push("Ivan");
            names.Push("Dragan");
            names.Push("Ani");

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(names);

            Console.WriteLine(stack.IsEmpty());
        }
    }
}
