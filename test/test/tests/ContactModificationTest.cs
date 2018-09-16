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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModifiedContact = oldContacts[0];

            app.Contact.ModifyCont(toBeModifiedContact, newFIO);

            List<ContactData> newContacts = ContactData.GetAll();

            toBeModifiedContact.Firstname = newFIO.Firstname;
            toBeModifiedContact.Lastname = newFIO.Lastname;
            newContacts.Sort();
            oldContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                if (contact.Id == toBeModifiedContact.Id)
                {
                    Assert.AreEqual(contact.Firstname, toBeModifiedContact.Firstname);
                }
            }
        }
    }
}

   