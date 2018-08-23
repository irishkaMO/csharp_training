﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContacts : AuthTestBase

    {
        [Test]
        public void DeleteContactByEditForm()
        {
            app.Contact.CheckForAvailabilityСontact();
            List<Contact> oldContact = app.Contact.GetContactList();
            app.Contact.DeleteContOnEdit();
            app.Navigator.GoToHomePage();
            List<Contact> newContact = app.Contact.GetContactList();
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void DeleteContactByHomePage()
        {
            app.Contact.CheckForAvailabilityСontact();
            List<Contact> oldContact = app.Contact.GetContactList();
            app.Contact.DeleteContOnHome();
            app.Navigator.GoToHomePage();
            List<Contact> newContact = app.Contact.GetContactList();
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}

   