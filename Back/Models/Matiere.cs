using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace apiEDT.Back.Models
{
    public class Matiere
    {
        [Key]
        public int id_mat { get; set; }
        public int id_ue { get; set; }
        public int id_mod { get; set; }
        public int id_period { get; set; }
        public string nom { get; set; }
        public string label { get; set; }
        public int nbH { get; set; }
        public string couleur { get; set; }
        public string themes { get; set; }
        public string typeEns { get; set; }
    }
}