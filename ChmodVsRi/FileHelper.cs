using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi
{
    class FileHelper
    {
        static string workDirectoryName = "WorkDirectory";
        string workDirectoryPath;
        public FileHelper()
        {
            workDirectoryPath = this.GetType().Assembly.Location;

            if (!Directory.Exists(workDirectoryPath + workDirectoryName))
            {
                Directory.CreateDirectory(workDirectoryName);
            }
            Console.WriteLine(workDirectoryPath);
        }

        public string getWorkDirectory()
        {
            return workDirectoryPath;
        }
    }
}
