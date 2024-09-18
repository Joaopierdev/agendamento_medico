using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoMedico.Models
{
    public class Agendamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; private set; }
        public Paciente Paciente { get; private set; }
        public Medico Medico { get; private set; }
        public DateTime Data { get; private set; }

        public Agendamento() { }

        public Agendamento(Paciente paciente, Medico medico)
        {
            Paciente = paciente;
            Medico = medico;
        }
    }
}
