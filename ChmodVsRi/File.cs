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
        public Rights ownerRights { get; set; }
        public Rights groupRights { get; set; }
        public Rights otherRights { get; set; }

        public File(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
            this.ownerRights = new Rights();
            this.groupRights = new Rights();
            this.otherRights = new Rights();
        }
        public File(FileInfo fileInfo, Rights ownerRights, Rights groupRights, Rights otherRights)
        {
            this.fileInfo = fileInfo;
            this.ownerRights = ownerRights;
            this.groupRights = groupRights;
            this.otherRights = otherRights;
        }
        public string getRightsString()
        {
            string str = "-";
            str += ownerRights.getRightsString();
            str += groupRights.getRightsString();
            str += otherRights.getRightsString();
            return str;
        }
    }
}
