using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    /// <summary>
    /// Summary description for AccountCreationTests
    /// </summary>
    [TestFixture]
    public class AccountCreationTests : BaseTest
    {
        [SetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("config_defaults_inc.php");
            using (Stream localFile = File.Open("C:\\Users\\User\\source\\repos\\pft\\mantis-tests\\mantis-tests\\config_defaults_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("config_defaults_inc.php", localFile);
            }
                
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Register(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("config_defaults_inc.php");
        }
    }
}
