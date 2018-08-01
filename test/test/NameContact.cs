using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class NameContact
    {
        private string firstname;
        private string lastname;
        private string middlename;
        public NameContact(string firstname, string middlename, string lastname)
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
       


    }
}
