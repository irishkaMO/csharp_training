using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ModifyContacts : BaseTest

    {
        [Test]
        public void ModifyContact()
        {
            Contact newFIO = new Contact("smena");
            newFIO.Middlename = "grupy";
            newFIO.Lastname = "modif";
            app.Contact.ModifyCont(newFIO);
        }
    }
}

   