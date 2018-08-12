using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class KontactCreationTest:AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            
            app.Contact.GoToAddNewContacPage();
            app.Contact.СontactForm (new Contact ("Irina",  "sys", "Korteleva"));
            app.Contact.CreateContact();
            app.Auth.Logout();
        }
    }
 }   
