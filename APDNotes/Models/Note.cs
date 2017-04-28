using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APDNotes.Models

{


    public class Note
    {
        string client;
        string writer;
        string checker;
        string firstDay;
        string lastDay;
        string status;
        string dateSubmited;

        public Note(string client,string writer, string checker, string firstDay, string lastDay, string status, string dateSubmited)
        {
            this.Writer = writer;
            this.Checker = checker;
            this.FirstDay = firstDay;
            this.LastDay = lastDay;
            this.Status = status;
            this.DateSubmited = dateSubmited;
            this.Client = client;
        }
        public Note() { }

        public string Writer
        {
            get { return writer; }
            set { writer = value; }
        }
        public string Checker
        {
            get { return checker; }
            set { checker = value; }
        }
        public string FirstDay
        {
            get { return firstDay; }
            set { firstDay = value; }
        }
        public string LastDay
        {
            get { return lastDay; }
            set { lastDay = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string DateSubmited
        {
            get { return dateSubmited; }
            set { dateSubmited = value; }
        }
        public string Client
        {
            get { return client; }
            set { client = value; }
        }
    }
}