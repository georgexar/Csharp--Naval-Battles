using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naval_Battles
{


    public class Data
    {
        private static OleDbConnection conn;
        private static string uri = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NavalBattlesDatabase.mdb;";

        public static void init()
        {
            conn = new OleDbConnection(uri);
        
        }

        public static void saveData(bool won, int duration)
        {
            conn.Open();

            string sql = "INSERT INTO userInfo([username], [won], [gameTime]) VALUES(@name, @won, @time)";
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@name", Program.getUsername);
            cmd.Parameters.AddWithValue("@won", won);
            cmd.Parameters.AddWithValue("@time", duration);

            cmd.ExecuteNonQuery();

            conn.Close();


        }

        public static int getWins()
        {

            conn.Open();

            string sql = "SELECT * FROM userInfo WHERE [username]=@name AND [won]=@value";
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@name", Program.getUsername);
            cmd.Parameters.AddWithValue("@value", true);

            OleDbDataReader reader = cmd.ExecuteReader();
            int wins = 0;
            while(reader.Read())
            {
                wins++;
            }
            reader.Close();
            conn.Close();
            return wins;
        }

        public static int getLoses()
        {


            conn.Open();
            string sql = "SELECT * FROM userInfo WHERE username=[@name] AND won=[@value]";
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@name", Program.getUsername);
            cmd.Parameters.AddWithValue("@value", false);

            OleDbDataReader reader = cmd.ExecuteReader();
            int loses = 0;
            while (reader.Read())
            {
                loses++;
            }
            reader.Close();
            return loses;
            
        }

    }
}
