using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200_Team8.Models
{
    public class Profile
    {
        public Guid profileID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        public string businessUnit { get; set; }
        public DateTime hireDate { get; set; }
        public string jobTitle { get; set; }

    }
}