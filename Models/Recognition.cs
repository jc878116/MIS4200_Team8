using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200_Team8.Models
{
    public class Recognition
    {
        public int recognitionID { get; set; }

        [Display(Name="Core value recognized")]
        [Range(1, 7, ErrorMessage = "Please select a core value from the dropdown")]
        public CoreValue award { get; set; }

        //Prefill to logged in employee
        [Display(Name = "Employee giving the recognition")]
        public Guid recognizor { get; set; }

        //Dropdown list of all registered employees
        [Display(Name = "Employee receiving the recognition")]
        public Guid recognized { get; set; }

        [Display(Name = "Date recognition given")]
        public DateTime recognitionDate { get; set; }

        //Text field for a little description
        //public string descritption { get; set; }

        public enum CoreValue
        {
            Balance=1,
            Culture=2,
            DeliveryExcellence=3,
            GreaterGood=4,
            Innovation=5,
            IntegrityAndOpenness=6,
            Stewardship=7
        }
               
        [ForeignKey("recognizor")]
        public virtual Profile employeeGiving { get; set; }

        [ForeignKey("recognized")]
        public virtual Profile employeeGetting { get; set; }
    }
}