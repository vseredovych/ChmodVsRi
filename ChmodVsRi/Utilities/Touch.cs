using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi.Utilities
{
    class Touch
    {
        private string fileName;
        public void CommandTouch(string[] _fileName, FileRepository repo)
        {
            fileName = _fileName[0];
            FileInfo fileI = new FileInfo(fileName);
            File file = new File(fileI);
            repo.AddToRepository(file); 

        }
    }
}
