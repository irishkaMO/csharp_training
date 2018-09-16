using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
   
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Antoshka");
            newData.Header = "grupy";
            newData.Footer = "modif";

            app.Group.CheckForAvailabilityGroup();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModify = oldGroups[0];

            app.Group.Modify(toBeModify, newData);

            List<GroupData> newGroups = GroupData.GetAll();

            toBeModify.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
