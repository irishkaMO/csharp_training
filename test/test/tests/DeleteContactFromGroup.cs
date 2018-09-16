using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.Count == 0)
            {
                app.Contact.CheckForAvailabilityСontact();
                ContactData newContact = ContactData.GetAll()[0];
                app.Contact.AddContactToGroup(newContact, group);
                oldList = group.GetContacts();
            }

            ContactData contact = oldList[0];
           
            app.Contact.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

