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

        public ContactHelper CreateContact()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

       public ContactHelper ModifyCont(string id, Contact newFIO)
        {
            manager.Navigator.GoToEditContactPage(id);
            manager.Contact.СontactForm(newFIO);
            manager.Contact.ModifyContact();
            manager.Auth.Logout();

            return this;
        }

        public ContactHelper DeleteCont(string id)
        {
            manager.Navigator.GoToEditContactPage(id);
            manager.Contact.DeleteContact();
            manager.Auth.Logout();

            return this;
        }

        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/form[1]/input[22]")).Click();
            
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/form[2]/input[2]")).Click();

            return this;
        }

        public ContactHelper СontactForm(Contact FIO)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(FIO.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(FIO.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(FIO.Lastname);

            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(FIO.Nickname);

            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(FIO.Address);

            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(FIO.BirthdayDay);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(FIO.BirthdayMonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(FIO.BirthdayYear);

            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(FIO.Home);
            return this;
        }

        public ContactHelper GoToAddNewContacPage()
        {

            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
       
    }
}
