using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoMedico.Models
{
    public class Medico
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Especialidade { get; private set; }

        public Medico() { }

        public Medico(string id, string nome, string especialidade)
        {
            Id = id;
            Nome = nome;
            Especialidade = especialidade;
        }

        public Medico(string nome, string especialidade)
        {
            Nome = nome;
            Especialidade = especialidade;
        }
    }
}
