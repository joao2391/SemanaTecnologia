using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechWeek2017.Models {
    public class Evento {

        [Key]
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataEvento { get; set; }


       

    }
}