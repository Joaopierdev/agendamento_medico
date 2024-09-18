using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoMedico.Models
{
    public class Paciente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }


        public Paciente() { }
        public Paciente(string id, string nome, string email, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Ativo = ativo;
        }

        public Paciente(string nome, string email, bool ativo)
        {
            Nome = nome;
            Email = email;
            Ativo = ativo;
        }
    }
}
