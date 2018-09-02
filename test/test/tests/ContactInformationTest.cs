using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{  
    [TestFixture]
   public class ContactInformationTest: AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.CetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails,fromForm.AllEmails);
        }
        
        [Test]
        public void TestContactInformationDetails()
        {
            app.Contact.CreateContact();

            ContactData fromdetails = app.Contact.GetContactInformationDetails(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromdetails.AllName, fromForm.AllName);
            Assert.AreEqual(fromdetails.Address, fromForm.Address);
            Assert.AreEqual(fromdetails.HomePhoneWithPrefix, fromForm.HomePhoneWithPrefix);
            Assert.AreEqual(fromdetails.MobilePhoneWithPrefix, fromForm.MobilePhoneWithPrefix);
            Assert.AreEqual(fromdetails.WorkPhoneWithPrefix, fromForm.WorkPhoneWithPrefix);
            Assert.AreEqual(fromdetails.FaxFoneWithPrefix, fromForm.FaxFoneWithPrefix);
            Assert.AreEqual(fromdetails.Email, fromForm.Email);
            Assert.AreEqual(fromdetails.Email2, fromForm.Email2);
            Assert.AreEqual(fromdetails.Email3, fromForm.Email3);
        }
    }
}


