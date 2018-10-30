using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestingSwitches
{
    class Program
    {
        public static string pos_x { get; private set; }
        public static string pos_y { get; private set; }
        public static string height { get; private set; }
        public static string width { get; private set; }

        static void Main(string[] args)
        {
            var p = new Program();

            int i = 0;
            while (i < args.Length)
            {
                Console.WriteLine("arg: " + args[i]);
                var command = args[i];
                switch (command)
                {
                    case "-x":
                        Console.WriteLine(command + " " + args[++i]);
                        pos_x = args[i];
                        break;
                    case "-y":
                        Console.WriteLine(command + " " + args[++i]);
                        pos_y = args[i];
                        break;
                    case "-h":
                        Console.WriteLine(command + " " + args[++i]);
                        height = args[i];
                        break;
                    case "-w":
                        Console.WriteLine(command + " " + args[++i]);
                        width = args[i];
                        break;
                    default:
                        if (i == args.Length - 1)
                        {
                            Console.WriteLine("process name: " + command);

                        }
                        else
                            Console.WriteLine("unknown parameters");
                        break;
                }


                ++i;
            }

        }
    }
}
