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
        private readonly string chmodParam = "rwx";
        private readonly string chmodParamTarget = "guoa";
    

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
                Console.Write("/" + fileHelper.getDirectoryName() + "/# ");
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
            foreach(string el in repo.getFileNamesAndRights())
            {
                Console.WriteLine(el);
            }
        }
        public void CommandChmod(File file, string changeForWhom, string changeHow, string AddOrRemove)
        {
            bool operation;
            if (AddOrRemove == "+")
            {
                operation = true;
            }
            else
            {
                operation = false;
            }

            if (changeForWhom.Contains("u"))
            {
                chmodChangeRights(file.ownerRights, changeHow, operation);
            }
            if (changeForWhom.Contains("g"))
            {
                chmodChangeRights(file.groupRights, changeHow, operation);
            }
            if (changeForWhom.Contains("o"))
            {
                chmodChangeRights(file.otherRights, changeHow, operation);
            }
            if (changeForWhom.Contains("a"))
            {
                chmodChangeRights(file.ownerRights, changeHow, operation);
                chmodChangeRights(file.groupRights, changeHow, operation);
                chmodChangeRights(file.otherRights, changeHow, operation);
            }
        }

        private void chmodChangeRights(Rights rights, string changeHow, bool operation)
        {
            if (changeHow.Contains("r"))
            {
                rights.read = operation;
            }
            if (changeHow.Contains("w"))
            {
                rights.write = operation;
            }
            if (changeHow.Contains("x"))
            {
                rights.execute = operation;
            }
        }
        private bool ParseChmodParameters(string[] parameters)
        {
            string changeForWhom = "";
            string changeHow = "";
            string AddOrRemove = "";


            if (parameters[0].Contains("+"))
            {
                AddOrRemove = "+";
            }
            else if (parameters[0].Contains("-"))
            {
                AddOrRemove = "-";
            }
            else{
                return false;
            }

            string[] operationParameters = parameters[0].Split('-', '+');
            
            /////////////////////////////////////////////
            //check target
            foreach (char el in operationParameters[0])
            {
                if (chmodParamTarget.Contains(el))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            changeForWhom = operationParameters[0];

            //check operations
            foreach (char el in operationParameters[1])
            {
                if (chmodParam.Contains(el))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }


            changeHow = operationParameters[1];
            /////////////////////////////////////////////
            File file = repo.getFileByName(parameters[1]);
            CommandChmod(file, changeForWhom, changeHow, AddOrRemove);
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
