using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Veiled_Kashmir_Admin_Panel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new container());
        }
    }

    class userinfo
    {
        public static bool loggedin;
        public static String username;
    }


    class DBConnect
    {
        MySqlConnection conn;
       

        public DBConnect()
        {
           //  conn = new MySqlConnection("SERVER=localhost;DATABASE=lalchowklocal;USER=root;PASSWORD=password1;");

             conn = new MySqlConnection("SERVER=182.50.133.78;DATABASE=lalchowk;USER=lalchowk;PASSWORD=Lalchowk@123uzmah;");
              
        }

       

        public bool openConnection()
        {
            try
            {
                conn.Open();
                
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Cannot connect to Server.");
                return false;
            }
        }
        public bool closeConnection()
        {
            try
            {
               
                conn.Close();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        public void nonQuery(String command)
        {
            if (this.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                this.closeConnection();
            }

        }

       

        /*      public MySqlDataAdapter AdapterQuery(String command)
              {
                  if (this.openConnection() == true)
                  {
                      MySqlCommand cmd = new MySqlCommand(command, conn);
                          cmd.ExecuteNonQuery();
                      this.closeConnection();
                  }
                  return (null);

              } */


        public MySqlDataReader Query(String command)
        {
            MySqlDataReader datareader;
            if (this.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(command, conn);
                datareader = cmd.ExecuteReader();

                return (datareader);
            }

            return (null);
        }

        public int Count(String command)
        {
            int count = -1;
            if (this.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(command, conn);
                count = int.Parse(cmd.ExecuteScalar() + "");
                this.closeConnection();
                return (count);

            }
            return (-1);

        }
        public float Avg(String command)
        {
            float avg = -1;
            if (this.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(command, conn);
                avg = float.Parse(cmd.ExecuteScalar() + "");
                this.closeConnection();
                return (avg);

            }
            return (-1);

        }
    }
}
