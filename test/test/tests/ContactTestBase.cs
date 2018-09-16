using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class ContactTestBase:AuthTestBase
    {

        [TearDown]
        public void CompareContactUI_DB()
        {
            if (PERFORM_LONG_UI_CHEKS)
            {
                List<ContactData> fromUI = app.Contact.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
     
}
