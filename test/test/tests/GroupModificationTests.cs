using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests :AuthTestBase
   
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Antoshka");
            newData.Header = "grupy";
            newData.Footer = "modif";
            app.Group.CheckForAvailabilityGroup();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Modify(0, newData);
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
