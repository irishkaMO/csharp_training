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
            List<Contact> oldContact = app.Contact.GetContactList();
            app.Contact.CreateContact();
            List<Contact> newContact = app.Contact.GetContactList();
            Assert.AreEqual(oldContact.Count + 1, newContact.Count);
        }
    }
}