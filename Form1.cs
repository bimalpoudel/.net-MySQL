using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySQLTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //string MyConString = "DRIVER={MySQL ODBC 5.3 Unicode Driver};SERVER=localhost;DATABASE=DATABASE;UID=USERNAME;PASSWORD=PASSWORD;OPTION=3";
                //string MyConString = "DSN=mysql64;SERVER=localhost;DATABASE=DATABASE;UID=USERNAME;PASSWORD=PASSWORD;OPTION=3";
                string cs = "SERVER=localhost;DATABASE=DATABASE;UID=USERNAME;PASSWORD=PASSWORD;";
                MySqlConnection connection = new MySqlConnection(cs);
                MySqlCommand command; // = new MySqlCommand();
                connection.Open();

                try
                {
                    // http://www.codeproject.com/Tips/423233/How-to-Connect-to-MySQL-Using-Csharp
                    // insert block
                    // select block
                    command = connection.CreateCommand();
                    command.CommandText = "SELECT `ENGINE`, `SUPPORT`, `COMMENT` FROM INFORMATION_SCHEMA.`ENGINES` WHERE `ENGINE` NOT LIKE @BAD;";
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    // display block
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if(connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
