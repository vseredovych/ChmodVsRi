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
            workDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(workDirectoryPath + workDirectoryName))
            {
                Directory.CreateDirectory(workDirectoryName);
            }
        }
        public void FileFillRepository(FileRepository repo)
        {
            DirectoryInfo dir = new DirectoryInfo(workDirectoryPath + workDirectoryName);
            FileInfo[] Files = dir.GetFiles("*.txt");

            foreach (FileInfo fileInfo in Files)
            {
                File newFile = new File(fileInfo, new Rights());
                repo.AddToRepository(newFile);
            }
        }

        public string getDirectoryPath()
        {
            return workDirectoryPath;
        }
        public string getDirectoryName()
        {
            return workDirectoryName;
        }
    }
}
