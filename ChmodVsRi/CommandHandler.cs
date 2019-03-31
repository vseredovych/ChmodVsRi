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
                    CommandLs();
                    break;


            }
        }
        void CommandPwd()
        {
            Console.WriteLine(fileHelper.getDirectoryName());          
        }
        void CommandLs()
        {
            foreach(string el in repo.getFileNames())
            {
                Console.WriteLine(el);
            }
        }

    }
}
