using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit.test
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void TestContactCreation()
        {
            List<ContactData> oldContact = app.Contact.GetContactList();
            ContactData newContact= new ContactData()
            {
                Name = "test"
            };
            app.Contact.Add(newContact);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldContact.Add(newContact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }

}
