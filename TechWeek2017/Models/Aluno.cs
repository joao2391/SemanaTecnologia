using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechWeek2017.Models {
    public class Aluno {
        
        
        [Key]
        public int AlunoId { get; set; }
        [Required(ErrorMessage = "Preencha o nome do aluno/participante")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Ra { get; set; }
        

    }
}