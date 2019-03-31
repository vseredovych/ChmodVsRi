using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi
{
    class FileRepository
    {
        List<File> files;
        public FileRepository()
        { 
            files = new List<File>();
        }
        public void AddToRepository(File file)
        {
            files.Add(file);
        }
        public string[] getFileNames()
        {
            List<string> names = new List<string>();
            foreach (File el in files)
            {
                names.Add(el.fileInfo.Name);
            }
            return names.ToArray();
        }
    }
}
