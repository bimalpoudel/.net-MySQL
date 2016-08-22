using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLTest
{
    public class Records
    {
        public string SQL;
        public List<Column> columns;
        public List<Parameter> parameters;

        public Records()
        {
            this.SQL = "";
            this.columns = new List<Column>();
            this.parameters = new List<Parameter>();
        }

        public void testSetup()
        {
            //Records r = new Records();
            //this.command = this.connection.CreateCommand();
            this.SQL = "SELECT `ENGINE`, `SUPPORT`, `COMMENT` FROM INFORMATION_SCHEMA.`ENGINES` WHERE `ENGINE` NOT LIKE @BAD;";

            //this.parameters = new List<Parameter>();
            this.parameters.Add(new Parameter("@BAD", "%random%"));

            //this.columns = new List<Column>();
            this.columns.Add(new Column("ENGINE", 70, false));
            this.columns.Add(new Column("SUPPORT", 70, false));
            this.columns.Add(new Column("COMMENT", 120, true));

            // this.renderTo(ref dataGridView1);
        }

        public void renderTo(ref DataGridView dgv)
        {
            MySqlConnection connection;
            MySqlCommand command;
            MySqlDataAdapter da;
            DataSet ds;

            string cs = new ConnectionString().ToString();
            connection = new MySqlConnection(cs);
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = this.SQL;

            for (int pi = 0; pi < this.parameters.Count(); ++pi)
            {
                command.Parameters.AddWithValue(this.parameters[pi].name, this.parameters[pi].value);
            }

            command.ExecuteNonQuery();

            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);

            int tableIndex = 0; // which table set?
            int maxColumns = Math.Min(this.columns.Count(), ds.Tables[tableIndex].Columns.Count);
            for (int ci = 0; ci < maxColumns; ++ci)
            {
                ds.Tables[tableIndex].Columns[ci].ColumnName = this.columns[ci].name;
            }

            dgv.DataSource = ds.Tables[tableIndex].DefaultView;
            for (int ci = 0; ci < maxColumns; ++ci)
            {
                dgv.Columns[ci].Width = this.columns[ci].width;
                dgv.Columns[ci].Resizable = this.columns[ci].resizable();
            }
        }
    }
}
