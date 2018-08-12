using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests:AuthTestBase
    {
        [Test]
        public void CroupCreationTest()
        {
            GroupData group = new GroupData("group2");
            group.Header = "test";
            group.Footer = "testing";
            app.Group.Create(group);

        }
        [Test]
        public void EmptyCroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Group.Create(group);
              
        }
    }
}
