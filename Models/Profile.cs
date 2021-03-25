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
        public businessUnit businessUnitLocation { get; set; }
        public enum businessUnit
        {
                Boston=1,
                Charlotte=2,
                Chicago=3,
                Cincinnati=4,
                Cleveland=5,
                Columbus=6,
                India=7,
                Indianapolis=8,
                Louisville=9,
                Miami=10,
                Seattle=11,
                StLouis=12,
                Tampa=13
        }

        public DateTime hireDate { get; set; }        

        public jobTitle jobTitleName { get; set; }
        public enum jobTitle
        {
                Consultant=1,
                SeniorConsultant=2,
                Manager=3,
                SeniorManager=4,
                Partner=5,
                VP=6,
                CSuite=7
        }

        public ICollection<Recognition> recognition { get; set; }

    }
}