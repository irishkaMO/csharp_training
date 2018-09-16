using System;
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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemovedContact = oldContacts[0];

            app.Contact.DeleteContactOnEdit(toBeRemovedContact);
            app.Navigator.GoToHomePage();

            
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemovedContact.Id);
            }
        }

        [Test]
        public void DeleteContactByHomePage()
        {
            app.Contact.CheckForAvailabilityСontact();

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeRemovedContact = oldContact[0];
            app.Contact.SelectContactOnHomePage(toBeRemovedContact.Id);
            app.Contact.DeleteContOnHome();
            app.Navigator.GoToHomePage();

            List<ContactData> newContact = ContactData.GetAll();
           
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
            foreach(ContactData contact in newContact)
                {
                Assert.AreNotEqual(contact.Id, toBeRemovedContact.Id);
                }
        }
    }
}

   