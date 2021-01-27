using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndianDresses.Models
{
    public class RegularClient
    {
        [Key]
        public int ClientID { get; set; } //Primery key for the Regular Customer table
        public string ClientName { get; set; }// Customer Name 
        public string ClientEmail { get; set; } //Customer email id
        public string Mobile { get; set; }//Customer contact
        public string Purpose { get; set; }//purpose for visit

        [DataType(DataType.Date)]
        public DateTime ArriveDate { get; set; } // customer arrived date
    }
}
