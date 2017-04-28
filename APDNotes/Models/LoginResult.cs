using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APDNotes.Models
{
    public class LoginResult
    {
        bool exist;
        string position;
        public LoginResult(bool exist, string position)
        {
            this.Exist = exist;
            this.Position = position;
        }

        public bool Exist
        {
            get { return exist; }
            set { exist = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }


    }
}
   