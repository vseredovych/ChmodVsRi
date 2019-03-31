using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi
{
    class CommandHandler
    {
        FileHelper fileHelper;

        CommandHandler()
        {
            fileHelper = new FileHelper();
        }
        public void ReadCommand()
        {
            string command = Console.ReadLine();
            HandleCommand(command);
        }

        void HandleCommand(string command)
        {
            switch (command)
            {
                case "pwd":
                    CommandPwd();
                    break;
                case "ls":

            }
        }
        void CommandPwd()
        {
            Console.WriteLine(fileHelper.getWorkDirectory());          
        }

    }
}
