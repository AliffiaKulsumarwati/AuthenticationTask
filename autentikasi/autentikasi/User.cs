using System;
using System.Collections.Generic;
using System.Text;

namespace Username
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Passwd { get; set; }

        public User(string firstname, string lasname, string uname, string passwd)
        {
            this.FirstName = firstname;
            this.LastName = lasname;
            this.UserName = uname;
            this.Passwd = passwd;
        }

        public void TampilAkun()//nanti
        {
            Console.WriteLine($"Nama: {this.FirstName} {this.LastName}");
            Console.WriteLine("Email/Username: " + this.UserName);
            Console.WriteLine("Password: " + this.Passwd);
        }

    }
}
