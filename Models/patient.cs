using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona_Ventilator.Models
{
    public class Patient
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Timestamp { get; set; }
        public int O2Level { get; set; }



    }
}
