using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaTracker.Models
{
    class RegisterModel
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
