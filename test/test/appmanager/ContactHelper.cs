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
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public void CreateContact()
        {

            driver.FindElement(By.Name("submit")).Click();

        }

        

        public void СontactForm(Contact FIO)
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
        }

        public void GoToAddNewContacPage()
        {

            driver.FindElement(By.LinkText("add new")).Click();
        }

    }
}
