using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Ports;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TechWeek2017.Models {
    public class Tempo {

        [Key]
        public int TempoId { get; set; }
        public int AlunoId { get; set; }
        public int EventoId { get; set; }
        [DisplayName("Tempo")]
        public Int64 Time { get; set; }
               
        public virtual Evento Evento { get; set; }
        public virtual Aluno Aluno { get; set; }

       
        
        
     
        
    }
}