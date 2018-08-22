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
            Contact newFIO = new Contact("smena");
            newFIO.Middlename = "contact";
            newFIO.Lastname = "Modification";
            app.Contact.CheckForAvailabilityСontact();
            List<Contact> oldContacts = app.Contact.GetContactList();
            app.Contact.ModifyCont(newFIO);
            List<Contact> newContacts = app.Contact.GetContactList();
            //Assert.False(oldContacts[0].Equals(newContacts[0]));
            Assert.True(newContacts[0].Equals(newFIO));
            //app.Contact.DeleteContOnHome();
        }
    }
}

   