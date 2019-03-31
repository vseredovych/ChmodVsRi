using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodVsRi
{
    class Rights
    {
        public bool read { get; set; }
        public bool write { get; set; }
        public bool execute { get; set; }

        public Rights()
        {
            read = false;
            write = false;
            execute = false;
        }
        public string getRightString()
        {

            return "";
        }
    }
}
