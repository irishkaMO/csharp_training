using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
                contact.Add(new ContactData(GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30),
                    Lastname = GenerateRandomString(30),
                    Address =GenerateRandomString(60)
                });
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contact = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"Contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contact.Add(new ContactData(parts[0])
                {
                    Middlename = parts[1],
                    Lastname = parts[2]
                });
            }
            return contact;
        }

        [Test,TestCaseSource ("ContactDataFromFile")]
        public void ContactCreationTest(ContactData contact)
        {
            //ContactData newFIO = new ContactData("NewFirstName", "NewLastName");
            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.CreateContact(contact);
            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}