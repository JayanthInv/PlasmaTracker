using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaTracker.Models
{
    
   public class PlasmaUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string BloodGroup { get; set; }
        public int Date { get; set; }
    }
}
