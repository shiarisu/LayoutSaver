using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windows_layout_save;

namespace ConsoleTestingSwitches
{
    class Program
    {
        public int PosX { get; private set; } = 0;
        public int PosY { get; private set; } = 0;
        public int Height { get; private set; } = 600;
        public int Width { get; private set; } = 600;
        public string Procname { get; private set; }
        public bool Forced { get; private set; } = false;

        static void Main(string[] args)
        {
            var p = new Program();

            int i = 0, tmp = 0, coordsSet = 0;
            if (args.Length == 0)
            {
                var help = @"
usage:
  Program.exe -x val -y val -h val -w val -f procname

xyhw are integers which can have negative value

-x --x        x position
-y --y        y position
-h --height   height
-w --width    width

-f            if present doesn't require all xyhw arguments to be present,
              uses default values instead
                ";
                Console.WriteLine(help);
                return;
            }
            while (i < args.Length)
            {
                var command = args[i];
                switch (command)
                {
                    case "-f":
                    case "--force":
                        p.Forced = true;
                        break;
                    case "-x":
                    case "--x":
                        coordsSet |= 1;
                        ++i;
                        if (i >= args.Length)
                        {
                            Console.WriteLine("wrong syntax");
                            return;
                        }
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.PosX = tmp;
                        break;
                    case "-y":
                    case "--y":
                        coordsSet |= 2;
                        ++i;
                        if (i >= args.Length)
                        {
                            Console.WriteLine("wrong syntax");
                            return;
                        }
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.PosY = tmp;
                        break;
                    case "-h":
                    case "--height":
                        coordsSet |= 4;
                        ++i;
                        if (i >= args.Length)
                        {
                            Console.WriteLine("wrong syntax");
                            return;
                        }
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.Height = tmp;
                        break;
                    case "-w":
                    case "--width":
                        coordsSet |= 8;
                        ++i;
                        if (i >= args.Length)
                        {
                            Console.WriteLine("wrong syntax");
                            return;
                        }
                        if (!int.TryParse(args[i], out tmp))
                        {
                            Console.Error.WriteLine("wrong parameter, input integer");
                            return;
                        }
                        p.Width = tmp;
                        break;
                    default:
                        if (i == args.Length - 1)
                        {
                            //Console.WriteLine("process name: " + command);
                            p.Procname = command;
                        }
                        else
                            Console.Error.WriteLine("unknown parameter: " + command);
                        break;
                }
                ++i;
            }

            p.WriteSettings();
            Console.WriteLine();
            //if forced mode is off and not all of xyhw coords are set by the user 
            if (!p.Forced && coordsSet != 15)
            {
                Console.Error.WriteLine("Provide all xyhw coordinates or use -f flag to force using default values");
                return;
            }
            //check if process name is correct
            if (p.Procname is null)
            {
                Console.Error.WriteLine("Provide a correct process name");
                return;
            }
            WindowsResizer wr = new WindowsResizer();
            wr.resize(p.PosX, p.PosY, p.Width, p.Height, p.Procname);

            Console.WriteLine();
        }

        private void WriteSettings()
        {
            Console.WriteLine("x:" + this.PosX + " y:" + this.PosY + " h:" + this.Height + " w:" + this.Width + " process name: \"" + this.Procname + "\"");
        }
    }
}
