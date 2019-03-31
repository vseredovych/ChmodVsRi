using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi.Utilities
{
    class Ls
    {
        private readonly string lsParameters = "-l";
        public void CommandLs(string[] parameters, FileRepository repository)
        {
            try
            {
                if (parameters == null || parameters.Length == 0)
                {
                    CommandLsWithNoParameters(repository);
                }
                else
                {
                    ParseLsParameters(parameters, repository);
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
        }
        private void ParseLsParameters(string[] parameters, FileRepository repository)
        {
            foreach (char el in parameters[0])
            {
                if (lsParameters.Contains(el))
                {
                    continue;
                }
                else
                {
                    throw new ChmodException("Wrong parameter for ls: " + el);
                }
            }
            CommandLsWithParameters(parameters, repository);
        }

        private void CommandLsWithParameters(string[] parameters, FileRepository repository)
        {
            if (parameters[0].Contains("-l"))
            {
                foreach (string el in repository.getFileNamesAndRights())
                {
                    Console.WriteLine(el);
                }
            }
            else
            {
                throw new ChmodException("Invalid operation fo ls!");
            }
        }

        private void CommandLsWithNoParameters(FileRepository repository)
        {
            foreach (string el in repository.getFileNames())
            {
                Console.WriteLine(el);
            }
        }
    }
}
