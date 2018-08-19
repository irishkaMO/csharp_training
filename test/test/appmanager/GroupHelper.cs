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

        public void CreateGroup()
        {
            GroupData group = new GroupData("group2");
            group.Header = "test";
            group.Footer = "testing";
            manager.Group.Create(group);
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
        public GroupHelper Select(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public GroupHelper RemovalGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public void CheckForAvailabilityGroup()
        {
            manager.Navigator.GoToGroupPage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                return;
            }
            manager.Group.CreateGroup();
            
        }
       
        public GroupHelper SubmitGroupCreation()
            {

                driver.FindElement(By.Name("submit")).Click();
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

      

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
