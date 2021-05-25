using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class NamedObject
    {
        public string Name
        {
            get;
            set;
        }

        public NamedObject(string name)
        {
            Name = name;
        }
    }
}
