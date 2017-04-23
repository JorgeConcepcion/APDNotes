using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APDNotes.Model
{
    public class User
    {

        string username;
        string password;
        string position;
        string usercode;

        public User()
        {
           
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
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public string Usercode
        {
            get { return usercode; }
            set { usercode = value; }
        }

    }
}