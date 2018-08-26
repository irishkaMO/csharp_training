﻿using System;
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

        public ContactHelper CreateContact(Contact myContact = null)
        {
            if (myContact == null)
            {
                myContact = new Contact("Irina", "sys", "Korteleva");
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

        public ContactHelper ModifyCont(Contact newFIO)
        {
            manager.Contact.CheckForAvailabilityСontact();
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
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
        private List<Contact> ContactCache = null;

        public List<Contact> GetContactList()
        {
            if (ContactCache == null)
            {
                ContactCache = new List<Contact>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name =\'entry\']"));
                foreach (IWebElement element in elements)

                {
                    IList<IWebElement> tds = element.FindElements(By.CssSelector("td"));
                    Contact contact = new Contact(tds[2].Text, tds[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    ContactCache.Add(contact); 
                }
            }
            return new List<Contact>(ContactCache);
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

        public ContactHelper СontactForm(Contact FIO)
        {
            Type(By.Name("firstname"),FIO.Firstname);
            Type(By.Name("middlename"),FIO.Middlename);
            Type(By.Name("lastname"),FIO.Lastname);
            Type(By.Name("nickname"),FIO.Nickname);
            Type(By.Name("address"),FIO.Address);
           
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(FIO.BirthdayDay);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(FIO.BirthdayMonth);
            Type(By.Name("byear"),FIO.BirthdayYear);
            Type(By.Name("home"),FIO.Home);
            return this;
        }
        
        public ContactHelper GoToAddNewContacPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
