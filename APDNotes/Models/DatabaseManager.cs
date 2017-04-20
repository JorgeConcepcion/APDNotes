using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ContactWeb.Models
{
    class DatabaseManager
    {

        string server;
        string username;
        string password;
        string database;

        public DatabaseManager(string server, string username, string password, string database)
        {
            this.Server = server;
            this.Username = username;
            this.Password = password;
            this.Database = database;
        }


        public void AddUser(User user)
        {

            string connstring = string.Format("Server=" + this.Server + "; database={0}; UID=" + this.Username + "; password=" + this.Password, this.Database);
            string query = "INSERT INTO Users(username,password,position,userCode) VALUES('" + user.Username + "','" + user.Password + "','" + user.Position + "','" + user.Usercode + "')";
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void AddNote(Note note)
        {
            string connstring = string.Format("Server=" + this.Server + "; database={0}; UID=" + this.Username + "; password=" + this.Password, this.Database);
            string query = "INSERT INTO Users(writer,checker,firstDay,lastDay,status,dateSubmited) VALUES('" + note.Writer + "','" + note.Checker + "','" + note.FirstDay + "','" + note.LastDay + "','"+note.Status+"','"+note.DateSubmited+"')";
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }



        //PROPERTIES
        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Database
        {
            get { return database; }
            set { database = value; }
        }
    }



   

}
