using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndianDresses.Models
{
    public class AvalibleStock
    {
        [Key]
        public int StockID { get; set; } //Primery key for the Services table
        public string Category { get; set; }//selling stock dress name
        public string Price { get; set; }//price of each dress
        public string AvalibleSize { get; set; }// size for each dress
        
       
    }
}
