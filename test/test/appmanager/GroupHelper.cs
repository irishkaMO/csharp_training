using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper: HelperBase
    {
       
        public GroupHelper(ApplicationManager manager):base(manager)
        {
        }
        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData> (groupCache);
        }

        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            Select(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }
    

        public void CreateGroup()
        {
            GroupData group = new GroupData("group2");
            group.Header = "test";
            group.Footer = "testing";
            manager.Group.Create(group);
        }

        public int GetGroupCount()
        {
          return  driver.FindElements(By.CssSelector("span.group")).Count; ;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
          
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            Select(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupPage();
            Select(p);
            RemovalGroup();
            ReturnToGroupPage();

            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            Select(group.Id);
            RemovalGroup();
            ReturnToGroupPage();

            return this;
        }

        public GroupHelper Select(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();

            return this;
        }

        public GroupHelper Select(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();

            return this;
        }

        public GroupHelper RemovalGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public void CheckForAvailabilityGroup()
        {
            manager.Navigator.GoToGroupPage();
            if (!IsElementPresent(By.Name("selected[]")))
                manager.Group.CreateGroup();
        }
       
        public GroupHelper SubmitGroupCreation()
        { 
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()

        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }


        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }
       
        public GroupHelper InitGroupCreation()
        {

             driver.FindElement(By.Name("new")).Click();
            return this;
        }
        
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
