using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using APDNotes.Models;


namespace APDNotes.Models
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
            string query = "INSERT INTO Users(clients,writer,checker,firstDay,lastDay,status,dateSubmited) VALUES('" +note.Client+"','"+ note.Writer + "','" + note.Checker + "','" + note.FirstDay + "','" + note.LastDay + "','"+note.Status+"','"+note.DateSubmited+"')";
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<Note> getWriterNotes(User user)
        {
            Note note;
            List<Note> notes = new List<Note>();
            string connstring = string.Format("Server=" + this.Server + "; database={0}; UID=" + this.Username + "; password=" + this.Password, this.Database);
            string query = "SELECT " +
                            "NotesLog.clients, NotesLog.writer,NotesLog.firstDay,NotesLog.lastDay,NotesLog.state,NotesLog.dateSubmited " +
                            "FROM" +
                            "(" +
                            "SELECT firstDay, MAX(id) AS id " +
                            "FROM NotesLog WHERE NotesLog.writer ='"+user.Username+"' " +
                            "GROUP BY firstDay, clients " +
                            ") AS a " +
                            "INNER JOIN " +
                            "NotesLog ON a.id = NotesLog.id";
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                note = new Note();
                note.Client= reader.GetString(0);
                note.Writer = reader.GetString(1);
                note.FirstDay = reader.GetString(2).Split(' ')[0];
                note.LastDay = reader.GetString(3).Split(' ')[0];
                note.Status = reader.GetString(4);
                note.DateSubmited = reader.GetString(5).Split(' ')[0];
                notes.Add(note);
            }
            return notes;

        }

        public List<Note> getCheckerNotes(User user)
        {
            Note note;
            List<Note> notes = new List<Note>();
            string connstring = string.Format("Server=" + this.Server + "; database={0}; UID=" + this.Username + "; password=" + this.Password, this.Database);
            string query = "SELECT " +
                            "NotesLog.clients, NotesLog.writer,NotesLog.firstDay,NotesLog.lastDay,NotesLog.state,NotesLog.dateSubmited " +
                            "FROM" +
                            "(" +
                            "SELECT firstDay, MAX(id) AS id " +
                            "FROM NotesLog " +
                            "GROUP BY firstDay, clients " +
                            ") AS a " +
                            "INNER JOIN " +
                            "NotesLog ON a.id = NotesLog.id " +
                            "WHERE " +
                            "state='Submited' || checker='"+user.Username+"' " +
                            "ORDER BY state";
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                note = new Note();
                note.Client = reader.GetString(0);
                note.Writer = reader.GetString(1);
                note.FirstDay = reader.GetString(2).Split(' ')[0];
                note.LastDay = reader.GetString(3).Split(' ')[0];
                note.Status = reader.GetString(4);
                note.DateSubmited = reader.GetString(5).Split(' ')[0];
                notes.Add(note);
            }
            return notes;

        }

        public LoginResult Login(User u)
        {
            LoginResult loginResult;
            string connstring = string.Format("Server=" + this.Server + "; database={0}; UID=" + this.Username + "; password=" + this.Password, this.Database);
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();
            string query = "SELECT EXISTS(SELECT 1 FROM Users WHERE username = '" + u.Username + "' AND PASSWORD='" + u.Password + "')";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if(reader.GetBoolean(0))
            {
                query = "SELECT position FROM Users WHERE username='" + u.Username + "'";
                reader.Close();
                cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                reader.Read();
                loginResult = new LoginResult(true, reader.GetString(0));
            }
            else
            {
                loginResult = new LoginResult(false, "");
            }
            return loginResult;

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
