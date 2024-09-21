using AgendamentoMedico.DTOs;
using AgendamentoMedico.Models;
using AgendamentoMedico.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamentoMedico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentosDbContext _context;
        private readonly AgendamentoService _agendamentoService;

        public AgendamentoController(AgendamentosDbContext context, AgendamentoService agendamentoService)
        {
            _context = context;
            _agendamentoService = agendamentoService;
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>>PostAgendamento(string MedicoId, AgendamentoDTO agendamentoDTO)
        {
            Paciente? paciente = await _context.pacientes.FirstOrDefaultAsync(p => p.Id == agendamentoDTO.PacienteId);

            if(paciente == null)
            {
                throw new Exception("Paciente mão existe");
            }

            Medico? medico = await _context.medicos.FirstOrDefaultAsync(m => m.Id == MedicoId);

            if (medico == null)
            {
                throw new Exception("Médico mão existe");
            }


            DateTime data;

            Agendamento agendamento = new Agendamento(
                paciente = paciente,
                medico = medico,
                data = DateTime.Now
            );

            _context.agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostAgendamento), new { id = agendamento.Id }, agendamento);
        }


    }
}
