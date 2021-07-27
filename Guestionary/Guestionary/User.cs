using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestionary
{
    public class User
    {
        public static int count = 0;
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        

        public User() { }
        public User(int count, string surname, string firstname, string phone, string mail)
        {
            Id=++count;
            Surname = surname;
            Firstname = firstname;
            Phone = phone;
            Mail = mail;
        }

        public bool IEquatable()
        {
            return true;
        }
    }
}
