using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            Contact newFIO = new Contact("NewFirstName", "NewLastName");
            List<Contact> oldContact = app.Contact.GetContactList();
            app.Contact.CreateContact(newFIO);
            List<Contact> newContact = app.Contact.GetContactList();
            oldContact.Add(newFIO);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}