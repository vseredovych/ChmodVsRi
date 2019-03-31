using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi
{
    class File
    {
        public FileInfo fileInfo {get; set;}
        private Rights ownerRights { get; set; }
        public File(FileInfo fileInfo, Rights ownerRights)
        {
            this.fileInfo = fileInfo;
            this.ownerRights = ownerRights;
        }
    }
}
