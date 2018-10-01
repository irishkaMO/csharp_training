using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        public static string GROUPWINTITLE = "Group editor";

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupDialogue();
            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4491",
                "GetItemCount","#0","");
            for(int i= 0; i< int.Parse(count); i++)
            {

                string item =aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4491", 
                    "GetText", "#0|#+i", "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void Remove()
        {
            CheckForAvailabilityGroup();
            OpenGroupDialogue();            
            aux.MouseClick("left", x, y);// координаты ссылки с  названием группы
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4493"); //нажатие кнопки удаления
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.62e4493");// клик по кнопке ок 
        }
        public GroupHelper CheckForAvailabilityGroup()

        {
            OpenGroupDialogue();
            List<GroupData> oldGroups = manager.Groups.GetGroupList();

            if (oldGroups.Count<=1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "First"
                };
                manager.Groups.Add(newGroup);
            }
            return this;
        }


        public void Add(GroupData newGroup)
        {
            OpenGroupDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4493");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4494");
        }

        private void OpenGroupDialogue()
        {
            manager.Aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.62e44912");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}