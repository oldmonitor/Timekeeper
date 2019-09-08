using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine((int)DateTime.Now.AddDays(1).DayOfWeek);
        }
    }
}
