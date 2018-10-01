using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    public class BaseTest
    {
        public static bool PERFORM_LONG_UI_CHEKS = true;
        public ApplicationManager app;
        
        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++ )
            {
                builder.Append((char)rnd.Next('a', 'z'));// builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 32))); 
            }
            return builder.ToString();
        }
    }
}
