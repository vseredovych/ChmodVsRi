using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi.Utilities
{
    public class ChmodException : Exception
    {
       public ChmodException(string message) : base(message) { }
    }
    class Chmod
    {
        private readonly string chmodParam = "rwx+-guoa";

        public void chmodExecuteWithParameters(string[] parameters, FileRepository repository)
        {
            try
            {
                ParseChmodParameters(parameters, repository);
            }
            catch(Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }

        }
        private void ParseChmodParameters(string[] parameters, FileRepository repository)
        {
            string changeForWhom = "";
            string changeHow = "";
            string AddOrRemove = "";

            if (parameters == null || parameters.Length == 0)
            {
                throw new ChmodException("No parameters for chmod were selected!");
            }

            if (parameters[0].Contains("+"))
            {
                AddOrRemove = "+";
            }
            else if (parameters[0].Contains("-"))
            {
                AddOrRemove = "-";
            }
            else
            {
                throw new ChmodException("No operation selected (+, -)!");
            }

            foreach (char el in parameters[0])
            {
                if (chmodParam.Contains(el))
                {
                    continue;
                }
                else
                {
                    throw new ChmodException("Wrong parameter for chmod: " + el);
                }
            }
            string[] operationParameters = parameters[0].Split('-', '+');

            if (operationParameters[0] != null)
            {
                changeForWhom = operationParameters[0];
            }
            else
            {
                throw new ChmodException("No target for chmod selected! (u, g, o)");
            }

            if (operationParameters[1] != null)
            {
                changeHow = operationParameters[1];
            }
            else
            {
                throw new ChmodException("No parameters for chmod selected! (r, w, x)");
            }

            try
            {
                File file = repository.getFileByName(parameters[1]);
                CommandChmod(file, changeForWhom, changeHow, AddOrRemove);
            }
            catch
            {
                Console.WriteLine("Invalid file: " + parameters[1]);
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
      
    }
}
