using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestingSwitches
{
    class Program
    {
        public int pos_x { get; private set; } = 0;
        public int pos_y { get; private set; } = 0;
        public int height { get; private set; } = 600;
        public int width { get; private set; } = 600;
        public string procname { get; private set; }
        public bool forced { get; private set; } = false;

        static void Main(string[] args)
        {
            var p = new Program();

            int i = 0, tmp = 0;
            while (i < args.Length)
            {
                Console.WriteLine("arg: " + args[i]);
                var command = args[i];
                switch (command)
                {
                    case "-f":
                        p.forced = true;
                        break;
                    case "-x":
                        Console.WriteLine(command + " " + args[++i]);
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.pos_x = tmp;
                        break;
                    case "-y":
                        Console.WriteLine(command + " " + args[++i]);
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.pos_y = tmp;
                        break;
                    case "-h":
                        Console.WriteLine(command + " " + args[++i]);
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.height = tmp;
                        break;
                    case "-w":
                        Console.WriteLine(command + " " + args[++i]);
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.width = tmp;
                        break;
                    default:
                        if (i == args.Length - 1)
                        {
                            Console.WriteLine("process name: " + command);
                            p.procname = command;
                        }
                        else
                            Console.Error.WriteLine("unknown parameters");
                        break;
                }


                ++i;
            }

            p.WriteSettings();

        }

        private void WriteSettings()
        {
            Console.WriteLine("x:" + this.pos_x + " y:" + this.pos_y + " h:" + this.height + " w:" + this.width + " proc:" + this.procname + " forced: " + this.forced);

        }
    }
}
