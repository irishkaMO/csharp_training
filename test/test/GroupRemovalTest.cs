using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests:BaseTest
    {
        [Test]
        public void GroupRemovalTest()
        {
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupPage();
            Select(1);
            RemovalGroup();
            ReturnToGroupPage();
        }
    }
}
