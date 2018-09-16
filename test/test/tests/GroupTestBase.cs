using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHEKS)
            {
                List<GroupData> fromUI = app.Group.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
