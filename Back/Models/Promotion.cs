using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace apiEDT.Back.Models
{
    public class Promotion
    {
        [Key]
        public int id_promo { get; set; }
        public int id_form { get; set; }
        public int num { get; set; }
        public string label { get; set; }
    }
}