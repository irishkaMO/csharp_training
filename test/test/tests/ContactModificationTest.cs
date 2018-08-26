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
        public void ContactModificationTest()
        {   
            ContactData newFIO = new ContactData("smena", "Modification");
            app.Contact.CheckForAvailabilityСontact();

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[0];
            app.Contact.ModifyCont(newFIO);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts[0].Firstname = newFIO.Firstname;
            oldContacts[0].Lastname = newFIO.Lastname;
            newContacts.Sort();
            oldContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            foreach(ContactData contact in newContacts)
                {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname, oldData.Firstname);
                }
                }
        }
    }
}

   