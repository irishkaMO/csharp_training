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
            app.Contact.DeleteContOnEdit();
        }

        [Test]
        public void DeleteContactByHomePage()
        {
            app.Contact.CheckForAvailabilityСontact();
            app.Contact.DeleteContOnHome();
        }
    }
}

   