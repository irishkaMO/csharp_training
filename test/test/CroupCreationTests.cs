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
            GoToHomePage();
            Login(new AccountData ("admin","secret"));
            GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(new GroupData ("irina","test","test"));
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
    }
}
