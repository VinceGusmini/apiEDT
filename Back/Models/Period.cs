using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace apiEDT.Back.Models
{
    public class Period
    {
        [Key]
        public int id_period { get; set; }
        public int id_promo { get; set; }
        public string label { get; set; }
        public int tDeb { get; set; }
        public int tFin { get; set; }
        
    }
}