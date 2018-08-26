using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests:AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {   

            app.Group.CheckForAvailabilityGroup();

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Remove(0);
            Assert.AreEqual(oldGroups.Count -1, app.Group.GetGroupCount());
            List<GroupData> newGroups = app.Group.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }


        }
    }
}
