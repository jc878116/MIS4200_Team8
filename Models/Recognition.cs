using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200_Team8.Models
{
    public class Recognition
    {
        public int recognitionID { get; set; }

        [Display(Name="Core value recognized")]
        public CoreValue award { get; set; }

        //Prefill to logged in employee
        [Display(Name = "Employee giving the recognition")]
        public string recognizor { get; set; }

        //Dropdown list of all registered employees
        [Display(Name = "Employee receiving the recognition")]
        public string recognized { get; set; }

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

        public int profileID { get; set; }

        public virtual Profile profile { get; set; }
    }
}