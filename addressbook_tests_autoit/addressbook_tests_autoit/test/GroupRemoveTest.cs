using System;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
           
            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Remove(newGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();
            NUnit.Framework.Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
