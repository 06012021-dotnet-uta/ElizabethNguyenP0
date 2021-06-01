using System;

namespace HelloWorldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name="Jane Doe";
            string age="0";
            //Console.WriteLine("Hello World!");
            Console.WriteLine("May I please get a name?");
            name = Console.ReadLine();
            Console.WriteLine("May I please get an age?");
            age = Console.ReadLine();
            Console.WriteLine("Hello, " + name + ". You're " + age + " years old.");
        }
    }
}
