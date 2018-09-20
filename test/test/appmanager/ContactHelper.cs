using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper :HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactData CetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmail = cells[4].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails =allEmail
            };
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGropFilter();
            SelectContactOnHomePage(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
        public void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToRemoveContact(group.Name);
            SelectContactOnHomePage(contact.Id);

            CommitRemoveContactFromGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }


        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void CommitRemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name); ;
        }

        private void SelectGroupToRemoveContact(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name); ;
        }

        private void ClearGropFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        internal ContactData GetContactInformationDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            manager.Navigator.GoToContactDetails();

            IWebElement div = driver.FindElements(By.Id("content"))[0];
            string divText = div.Text;
            List<string> lines = divText.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            string allName = lines[0];
            string address = lines[1];
            string homeFoneWithPrefix = lines[3];
            string mobileFoneWithPrefix = lines[4];
            string workFoneWithPrefix = lines[5];
            string faxFoneWithPrefix = lines[6];
            string email = lines[8];
            string email2 = lines[9];
            string email3 = lines[10];
            return new ContactData(allName)
            {
                AllName = allName,
                Address = address,
                HomePhoneWithPrefix = homeFoneWithPrefix,
                MobilePhoneWithPrefix = mobileFoneWithPrefix,
                WorkPhoneWithPrefix = workFoneWithPrefix,
                FaxFoneWithPrefix = faxFoneWithPrefix,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData  GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            manager.Contact.PressButtonEditContact(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homeFone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileFone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workFone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homeFoneDop = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string faxFone = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new ContactData(firstName, middleName, lastName)
            {   
               
                Address = address,
                MobilePhone = mobileFone,
                HomePhone = homeFone,
                WorkPhone = workFone,
                HomePhoneDop=homeFoneDop,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                FaxFone=faxFone,
            };

        }

        public ContactData CreateContact(ContactData myContact)
        {
            manager.Contact.GoToAddNewContacPage();
            manager.Contact.AllFildsContactForm(myContact);
            manager.Contact.SubmitContact();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("table#maintable")).Count > 0);

            return myContact;
        }

        public ContactData CreateContact()
        {
            ContactData myContact = new ContactData("Arina", "sys", "AKorteleva");

            return this.CreateContact(myContact);
        }
        
        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            ContactCache = null;

            return this;
        }

        public ContactHelper ModifyCont(ContactData newFIO)
        {
            manager.Contact.CheckForAvailabilityСontact();
            manager.Contact.PressButtonEditContact(0);
            manager.Contact.СontactForm(newFIO);
            manager.Contact.ModifyContactButton();

            return this;
        }

        public ContactHelper ModifyCont(ContactData contact, ContactData newFIO)
        {
            manager.Navigator.GoToContactEditPage(contact.Id);
            manager.Contact.СontactForm(newFIO);
            manager.Contact.ModifyContactButton();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper DeleteContOnEdit()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            manager.Contact.DeleteContactButton();
            return this;
        }
        public ContactHelper DeleteContactOnEdit(ContactData contact)
        {
            manager.Navigator.GoToContactEditPage(contact.Id);
            manager.Contact.DeleteContactButton();

            return this;
        }
        public ContactHelper DeleteContOnHome()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            ContactCache = null;
            driver.SwitchTo().Alert().Accept();

            return this;
        }
        public ContactHelper SelectContactOnHomePage(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();

            return this;
        }
        public void CheckForAvailabilityСontact()
        {
            manager.Navigator.GoToHomePage();
            if (!IsElementPresent(By.CssSelector("img[alt=\"Edit\"]")))
            {
                manager.Contact.CreateContact();
                manager.Navigator.GoToHomePage();
            }
        }
        private List<ContactData> ContactCache = null;

        public List<ContactData> GetContactList()
        {
            if (ContactCache == null)
            {
                ContactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name =\'entry\']"));
                foreach (IWebElement element in elements)

                {
                    IList<IWebElement> tds = element.FindElements(By.CssSelector("td"));
                    ContactData contact = new ContactData(tds[2].Text, tds[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    ContactCache.Add(contact); 
                }
            }
            return new List<ContactData>(ContactCache);
        }

        public ContactHelper ModifyContactButton()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/form[1]/input[22]")).Click();
            ContactCache = null;
            return this;
        }

        public ContactHelper DeleteContactButton()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/form[2]/input[2]")).Click();
            ContactCache = null;
            return this;
        }

        public ContactHelper СontactForm(ContactData FIO)
        {
            Type(By.Name("firstname"),FIO.Firstname);
            Type(By.Name("middlename"),FIO.Middlename);
            Type(By.Name("lastname"),FIO.Lastname);
            Type(By.Name("nickname"),FIO.Nickname);
            Type(By.Name("address"),FIO.Address);
           
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(FIO.BirthdayDay);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(FIO.BirthdayMonth);
            Type(By.Name("byear"),FIO.BirthdayYear);
            Type(By.Name("home"),FIO.HomePhone);

            return this;
        }

        public ContactHelper AllFildsContactForm (ContactData allfields)
        {
            Type(By.Name("firstname"), allfields.Firstname);
            Type(By.Name("middlename"), allfields.Middlename);
            Type(By.Name("lastname"), allfields.Lastname);
            Type(By.Name("address"), allfields.Address);
            Type(By.Name("home"), allfields.HomePhone);
            Type(By.Name("mobile"), allfields.MobilePhone);
            Type(By.Name("work"), allfields.WorkPhone);
            Type(By.Name("fax"), allfields.FaxFone);
            Type(By.Name("email"), allfields.Email);
            Type(By.Name("email2"), allfields.Email2);
            Type(By.Name("email3"), allfields.Email3);

            return this;
        }

        public ContactHelper GoToAddNewContacPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper PressButtonEditContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public int GetNumberSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text= driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
