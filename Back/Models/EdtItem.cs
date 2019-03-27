using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace apiEDT.Back.Models
{
    public class EdtItem
    {
        [Key]
        public int idItem { get; set; }
        public int idEdt { get; set; }
        public string idModule { get; set; }
        public int nbHeure { get; set;}
        
    }
}