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
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
