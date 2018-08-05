using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class Contact
    {
        private string firstname;
        private string lastname;
        private string middlename;

        private string nickname = "tets_nickname";
        private string address = "Grodno";
        private string home = "12345678";
        private string birthdayYear = "1983";
        private string birthdayDay = "8";
        private string birthdayMonth = "November";
        

        public Contact(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.middlename = middlename;
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname= value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string BirthdayYear
        {
            get
            {
                return birthdayYear;
            }
            set
            {
                birthdayYear = value;
            }
        }

        public string BirthdayDay
        {
            get
            {
                return birthdayDay;
            }
            set
            {
                birthdayDay = value;
            }
        }

        public string BirthdayMonth
        {
            get
            {
                return birthdayMonth;
            }
            set
            {
                birthdayMonth = value;
            }
        }
        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }





    }
}
