using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests:BaseTest
    {
        [Test]
        public void CroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData ("admin","secret"));
            app.Navigator.GoToGroupPage();
            app.Group.InitGroupCreation();
            app.Group.FillGroupForm(new GroupData ("irina","test","test"));
            app.Group.SubmitGroupCreation();
            app.Group.ReturnToGroupPage();
        }
    }
}
