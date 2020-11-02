using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_8113_5037
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome8113();
            Welcome5037();
            Console.ReadKey();
        }
        static partial void Welcome5037();

        private static void Welcome8113()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);

        }
    }
}
