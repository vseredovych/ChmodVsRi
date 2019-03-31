using ChmodVsRi.Utilities;
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
        private FileHelper fileHelper;
        private FileRepository repository;

        private Chmod chmod;
        private Ls ls;

        public CommandHandler()
        {
            chmod = new Chmod();
            ls = new Ls();

            fileHelper = new FileHelper();
            repository = new FileRepository();
            fileHelper.FileFillRepository(repository);
        }
        public void ReadCommand()
        {
            string command;
            do
            {
                Console.Write("/" + fileHelper.getDirectoryName() + "/# ");
                command = Console.ReadLine();
                ParseString(command);
            } while (command != "exit");
        }

        private void ParseString(string command)
        {
            string[] parameters = command.Split(' ');
            string cmd = parameters[0];
            parameters = parameters.Where((val, idx) => idx != 0).ToArray();
            HandleCommand(cmd, parameters);
        }

        private void HandleCommand(string command, string[] parameters)
        {
            switch (command)
            {
                case "pwd":
                    CommandPwd();
                    break;
                case "ls":
                    ls.CommandLs(parameters, repository);
                    break;
                case "chmod":
                    chmod.chmodExecuteWithParameters(parameters, repository);
                    break;
                default:
                    Console.WriteLine("Invalid command: " + command);
                    break;

            }
        }
        private void CommandPwd()
        {
            Console.WriteLine(fileHelper.getDirectoryName());          
        }
    }
}
