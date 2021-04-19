using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200_Team8.Models
{
    public class Profile
    {
        public Guid profileID { get; set; }

        [Required(ErrorMessage = "An employee first name is required")]
        [RegularExpression("^([a-zA-Z']+)$", ErrorMessage = "Employee first name may only include letters and an optional '")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "An employee last name is required")]
        [RegularExpression("^([a-zA-Z']+)$", ErrorMessage = "Employee last name may only include letters and an optional '")]
        public string lastName { get; set; }
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }

        
        [Range(1,13, ErrorMessage = "Please select a business unit from the dropdown")]
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
                [Display(Name = "St. Louis")]
                StLouis=12,
                Tampa=13
        }

        [Required(ErrorMessage = "A hire date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]  
        public DateTime hireDate { get; set; }

        
        [Range(1, 7, ErrorMessage = "Please select a job title from the dropdown")]
        public jobTitle jobTitleName { get; set; }
        public enum jobTitle
        {
                Consultant=1,
                [Display(Name = "Senior Consultant")]
                SeniorConsultant=2,
                Manager=3,
                [Display(Name = "Senior Manager")]
                SeniorManager=4,
                Partner=5,
                VP=6,
                [Display(Name = "C Suite")]
                CSuite=7
        }

        //public int totalRecognitions { get; set; }

        [ForeignKey("recognizor")]
        public ICollection<Recognition> employeeGiving { get; set; }

        [ForeignKey("recognized")]
        public ICollection<Recognition> employeeGetting { get; set; }

    }
}