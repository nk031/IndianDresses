using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndianDresses.Models
{
    public class OnlineSale
    {
        [Key]
        public int ID { get; set; }//foreign key
        public int ClientID { get; set; }// foreign key for client name
        public RegularClient Client { get; set; }


        public int StockID { get; set; }//foreign key
        public AvalibleStock Stock { get; set; }// foreign key of staff 
    }
}
