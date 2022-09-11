using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMvcApp.ViewModels
{
    public class UserProfileViewModel
    {
        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string ProfileImage { get; set; }
        public string Nickname { get; set; }
        public string Locale { get; set; }
        public string NameIdentifier { get; set; }
        public bool IsGoogle { get; set; }
    }
}
