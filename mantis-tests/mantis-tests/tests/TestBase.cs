﻿using NUnit.Framework;
using System;
using System.Text;


namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = false;
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupAplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
