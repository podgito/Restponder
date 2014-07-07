using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DummyAPI.Models.Account
{
    public class ApplicationUser : Microsoft.AspNet.Identity.IUser
    {
        public string Id { get; private set; }

        public string UserName { get; set; }

        public string PasswordHash { get; private set; }
    }
}

