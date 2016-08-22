using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLTest
{
    public class Parameter
    {
        public dynamic name;
        public dynamic value;

        public Parameter(dynamic name, dynamic value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
