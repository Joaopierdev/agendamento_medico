using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoMedico.DTOs
{
    public class AgendamentoDTO
    {
        public string PacienteId { get; set; }
        public DateTime DataAgendamento {  get; set; }
    }
}
