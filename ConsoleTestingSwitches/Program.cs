using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestingSwitches
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("whatevs");
            String tmp = Console.ReadLine();
            tmp.Split(' ');
            foreach (var item in tmp.Split(' '))
            {
                Console.WriteLine(item);

            }
            Console.WriteLine(tmp);

        }
    }
}
