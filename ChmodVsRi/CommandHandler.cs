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
        private FileRepository repo;

        public CommandHandler()
        {
            fileHelper = new FileHelper();
            repo = new FileRepository();
            fileHelper.FileFillRepository(repo);
        }
        public void ReadCommand()
        {
            string command;
            do
            {
                Console.Write("/ " + fileHelper.getDirectoryName() + "/ # ");
                command = Console.ReadLine();
                ParseString(command);
            } while (command != "exit");
        }


        private void HandleCommand(string command, string[] parameters)
        {
            switch (command)
            {
                case "pwd":
                    CommandPwd();
                    break;
                case "ls":
                    CommandLs();
                    break;
                case "chmod":
                    ParseChmodParameters(parameters);
                    break;

            }
        }
        private void CommandPwd()
        {
            Console.WriteLine(fileHelper.getDirectoryName());          
        }
        private void CommandLs()
        {
            foreach(string el in repo.getFileNames())
            {
                Console.WriteLine(el);
            }
        }
        public void CommandChmod(File file, string changeForWhom, string changeHow, bool AddOrRemove)
        {

        }

        private bool ParseChmodParameters(string[] parameters)
        {
            string changeForWhom;
            string changeHow;
            string AddOrRemove;

            if (parameters[0].Length > 3)
            {
                return false;
            }



            return true;
        }
        private void ParseString(string command)
        {
            string[] parameters = command.Split(' ');
            string cmd = parameters[0];
            parameters = parameters.Where((val, idx) => idx != 0).ToArray();
            HandleCommand(cmd, parameters);
        }
    }
}
