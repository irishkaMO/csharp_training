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
            ContactData newFIO = new ContactData("NewFirstName", "NewLastName");
            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.CreateContact(newFIO);
            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(newFIO);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}