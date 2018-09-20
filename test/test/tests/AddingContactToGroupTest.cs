using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTest : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Group.CheckForAvailabilityGroup();
            app.Contact.CheckForAvailabilityСontact();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> allContacts = ContactData.GetAll();

            ContactData contact;
            IEnumerable<ContactData> diff = allContacts.Except(oldList);
            if (diff.Count() == 0)
            {
                ContactData myContact = new ContactData(BaseTest.GenerateRandomString(15), "sys4", "AKorteleva4");// создание рандомных из-за  except функции, когда только одинаковые получаем 0
                app.Contact.CreateContact(myContact);
                contact = ContactData.GetAll().Except(oldList).First(); // что бы получить id нового контакта
            }
            else
            {
                contact = diff.First();
            }

            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
