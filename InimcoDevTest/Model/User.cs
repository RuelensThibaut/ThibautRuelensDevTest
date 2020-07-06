using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Threading.Tasks;

namespace InimcoDevTest.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> SocialSkills { get; set; }
        public List<SocialAccount> SocialAccounts { get; set; }

    }
}
