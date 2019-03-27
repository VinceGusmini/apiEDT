using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace apiEDT.Back.Models
{
    public class Uemodule
    {
        [Key]
        public int id_uemod { get; set; }
        public int id_form { get; set; }
        public string classif { get; set; }        
        public string nom { get; set; }
        public string label { get; set; }
    }
}