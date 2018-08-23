using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ModifyContacts : AuthTestBase
    {
        [Test]
        public void ModifyContact()
        {   
            Contact newFIO = new Contact("smena", "Modification");
            app.Contact.CheckForAvailabilityСontact();
            List<Contact> oldContacts = app.Contact.GetContactList();
            app.Contact.ModifyCont(newFIO);
            List<Contact> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newFIO.Firstname;
            oldContacts[0].Lastname = newFIO.Lastname;
            newContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

   