﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class KontactCreationTest:BaseTest
    {
 
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToAddNewContacPage();
            СontactForm (new Contact ("Irina",  "sys", "Korteleva"));
            CreateContact();
            Logout();
        }
    }
}
