using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


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

        public ContactData  CetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            manager.Contact.PressButtonEditContact(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homeFone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileFone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workFone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homeFoneDop = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address = address,
                MobilePhone = mobileFone,
                HomePhone = homeFone,
                WorkPhone = workFone,
                HomePhoneDop=homeFoneDop,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

        }

        public ContactHelper CreateContact(ContactData myContact = null)
        {
            if (myContact == null)
            {
                myContact = new ContactData("Irina", "sys", "Korteleva");
            }

            manager.Contact.GoToAddNewContacPage();
            manager.Contact.СontactForm(myContact);
            manager.Contact.SubmitContact();
            return this;
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

        public ContactHelper DeleteContOnEdit()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            manager.Contact.DeleteContactButton();
            return this;
        }

        public ContactHelper DeleteContOnHome()
        {
            
            driver.FindElement(By.CssSelector("input[name=\"selected[]\"]")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            ContactCache = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public void CheckForAvailabilityСontact()
        {
            manager.Navigator.GoToHomePage();
            if (IsElementPresent(By.CssSelector("img[alt=\"Edit\"]")))
            {
                return;
            }
            manager.Contact.CreateContact();
            manager.Navigator.GoToHomePage();
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
    }
}
