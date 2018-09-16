using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;



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
                    Lastname = parts[1],
                    Address = parts[2],
                    Email = parts[3],
                    FaxFone =parts[4]
                });
            }
            return contact;
        }
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactData>ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json")
                );

        }

        [Test,TestCaseSource ("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            //ContactData newFIO = new ContactData("NewFirstName", "NewLastName");
            List<ContactData> oldContact = ContactData.GetAll();
            app.Contact.CreateContact(contact);

            List<ContactData> newContact = ContactData.GetAll();

            //app.Auth.Logout();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
           
        }
    }
}