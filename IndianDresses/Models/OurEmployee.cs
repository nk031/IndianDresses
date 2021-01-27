using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndianDresses.Models
{
    public class OurEmployee
    {

        [Key]
        public int EmployeeID { get; set; } //Primery key for the Staff table
        public string EmployeeName { get; set; } // Staff Name on Shifts
        public string Address { get; set; }//Address of staff member
        public string MobileNumber { get; set; }// Staff Mobile 
       
        [DataType(DataType.Time)]
        public DateTime ShiftStart { get; set; } //when they join this job

        [DataType(DataType.Time)]
        public DateTime ShiftFinish { get; set; }// visa deatil for working eligibility

    }
}
