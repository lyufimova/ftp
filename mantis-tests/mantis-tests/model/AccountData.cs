﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AccountData
    { private string username;
        private string password;

        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Name { get; set; }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }

        }

        public string Email { get; set; }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }


    }
}
