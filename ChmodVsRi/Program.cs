using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("test");
            CommandHandler handler = new CommandHandler();
            handler.ReadCommand();

            Console.Read();
        }
    }
}
