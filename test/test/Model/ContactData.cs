using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string nickname = "tets_nickname";
        private string birthdayYear = "1982";
        private string birthdayDay = "8";
        private string birthdayMonth = "November";
        private string email = "irina_kort@mail.ru";
        private string email2 = "irka_kort@mail.com";
        private string email3 = "irishka_kort@gmail.com";
        private string home = "7777777777";
        private string mobile = "444444444";
        private string work = "5555555555";
        private string fax = "66666666666";
        private string address ="Grodno";
        private string allPhones;
        private string allEmails;
        private string allName;
        private string homePhoneWithPrefix;
        private string mobileFoneWithPrefix;
        private string workFoneWithPrefix;
        private string faxFoneWithPrefix;

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData(string firstname, string middlename, string lastname)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Email = this.email;
            Email2 = this.email2;
            Email3 = this.email3;
            HomePhone = this.home;
            WorkPhone = this.work;
            MobilePhone = this.mobile;
            FaxFone = this.fax;
            Address = this.address;
        }

        public ContactData(string firstname, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;            
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Lastname == other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Firstname.CompareTo(other.Firstname);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",Firstname,Lastname);
        }

        public string Firstname { get; set; }
       
        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Id { get; set; }
       
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

        public string Address { get; set; }
        public string AllName
        {
            get
            {
                if (allName != null)
                {
                    return allName;
                }
                else
                {
                    return ((Firstname) + " " + (Middlename) + " " + (Lastname));
                }
            }
            set
            {
                allName = value;
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
        public string HomePhone { get; set; }
        public string HomePhoneDop { get; set; }
        public string FaxFone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)+ CleanUpPhone(HomePhoneDop)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null||phone=="")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","") +"\r\n";
           
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string HomePhoneWithPrefix
        {
            get
            {
                if (homePhoneWithPrefix != null)
                {
                    return homePhoneWithPrefix;
                }
                else
                {
                    return ("H:" +" "+ (HomePhone));
                }
            }
            set
            {
                homePhoneWithPrefix = value;
            }
        }

        public string MobilePhoneWithPrefix
        {
            get
            {
                if (mobileFoneWithPrefix != null)
                {
                    return mobileFoneWithPrefix;
                }
                else
                {
                    return ("M:" + " " + (MobilePhone));
                }
            }
            set
            {
                mobileFoneWithPrefix = value;
            }
        }

        public string WorkPhoneWithPrefix
        {
            get
            {
                if (workFoneWithPrefix != null)
                {
                    return workFoneWithPrefix;
                }
                else
                {
                    return ("W:" + " " + (WorkPhone));
                }
            }
            set
            {
                workFoneWithPrefix = value;
            }
        }


        public string FaxFoneWithPrefix
        {
            get
            {
                if (faxFoneWithPrefix != null)
                {
                    return faxFoneWithPrefix;
                }
                else
                {
                    return ("F:" + " " + (FaxFone));
                }
            }
            set
            {
                faxFoneWithPrefix = value;
            }
        }


        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email," () ", "") +"\r\n";




        }
    }
}
