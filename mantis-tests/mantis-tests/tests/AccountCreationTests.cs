using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace mantis_tests
{


    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_defaults_inc.php");
            using (Stream localFile = File.Open("config_defaults_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_defaults_inc.php", localFile);
            }
                
        }


        [Test]
        public void TestAccountRegistration()

        {
            AccountData account = new AccountData("testuser", "password")
            {
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_defaults_inc.php");
        }
    }

}