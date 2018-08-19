﻿using System;
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
        public void GroupModificationTest ()
        {  
            GroupData  newData= new GroupData("smena");
            newData.Header = "grupy";
            newData.Footer = "modif";
            app.Group.CheckForAvailabilityGroup();
            app.Group.Modify(1, newData);
        }
    }
}
