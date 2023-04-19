using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string message = "This is test";
            string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine("[" + formattedDate + " INF] " + message);
            Console.ReadKey();
        }
    }
}
