using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Ports;
using System.ComponentModel.DataAnnotations;

namespace TechWeek2017.Models {
    public class Tempo {

        [Key]
        public int TempoId { get; set; }
        public int AlunoId { get; set; }
        public int EventoId { get; set; }
        public Int64 Time { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}