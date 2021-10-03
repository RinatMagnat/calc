using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Введите значение ");
            Console.Write(" ");
            string consol_string = Console.ReadLine();
            Calc calc = new Calc(consol_string);
            calc.Display();
            Console.ReadLine();
        }
    }
}
