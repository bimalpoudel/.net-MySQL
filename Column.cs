using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLTest
{
    public class Column
    {
        public string name;
        public int width;
        private bool resize = false;
        // other decorations

        public Column(string name, int width, bool resize = false)
        {
            this.name = name;
            this.width = width;
            this.resize = resize;
        }
        /**
         * Can we resize the column heads?
         */
        public DataGridViewTriState resizable()
        {
            DataGridViewTriState state = new DataGridViewTriState();

            if (this.resize)
            {
                state = DataGridViewTriState.True;
            }
            else
            {
                state = DataGridViewTriState.False;
            }

            return state;
        }
    }
}
