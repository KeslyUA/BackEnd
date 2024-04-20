using CitasMedicas.DTOs;
using CitasMedicas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CitasMedicas.Controllers

{
    [Route("paciente")]
    [ApiController]

    public class PacienteControllers : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        public PacienteControllers(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> GetAllPaciente()
        {
            var _lista = await this._pacienteService.GetList();
            if (_lista != null) return Ok(_lista);
            else return NotFound();
        }
        [HttpGet("{idPaciente}")]
        public async Task<IActionResult> GetById(int idPaciente)
        {
            var dpto = await this._pacienteService.Get(idPaciente);
            if (dpto != null) return Ok(dpto);
            else return NotFound();
            //guardar
        }
        [HttpPost("guardar")]
        public async Task<IActionResult> AddPaciente(PacienteDTO _paciente)
        {
            var dpto = await this._pacienteService.Add(_paciente);
            if (dpto != null) return Ok(dpto);
            else return NotFound();

            //actualizar
        }
        [HttpPut("actualizar/{idPaciente}")]
        public async Task<IActionResult> UpdatePaciente(int idPaciente, PacienteDTO paciente)
        {
            var _encontrado = await this._pacienteService.Get(idPaciente);
            if (_encontrado != null)
            {
                paciente.IdPaciente = _encontrado.IdPaciente;
                await this._pacienteService.Update(paciente);
                return Ok(new { Success = "Actualizado con exito" });
            }

            else return NotFound();
            //eliminar
        }
        [HttpDelete("eliminar/{idPaciente}")]
        public async Task<IActionResult> DeletePaciente(int idPaciente)
        {
            var _encontrado = await this._pacienteService.Get(idPaciente);
            if (_encontrado != null)
            {
                await this._pacienteService.Delete(idPaciente);
                return Ok(new { Success = "Eliminado con exito" });
            }

            else return NotFound();
        }
    }
}
