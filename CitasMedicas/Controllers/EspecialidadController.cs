using CitasMedicas.DTOs;
using CitasMedicas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CitasMedicas.Controllers
{
    [Route("especialidad")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly IEspecialidadService _especialidadService;
        public EspecialidadController(IEspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> GetAllEspecialidad()
        {
            var _lista = await this._especialidadService.GetList();
            if (_lista != null) return Ok(_lista);
            else return NotFound();
        }
        [HttpGet("{idEspecialidad}")]
        public async Task<IActionResult> GetById(int idEspecialidad)
        {
            var dpto = await this._especialidadService.Get(idEspecialidad);
            if (dpto != null) return Ok(dpto);
            else return NotFound();
            //guardar
        }
        [HttpPost("guardar")]
        public async Task<IActionResult> AddEspecialidad(EspecialidadDTO _especialidad)
        {
            var dpto = await this._especialidadService.Add(_especialidad);
            if (dpto != null) return Ok(dpto);
            else return NotFound();
            //actualizar
        }
        [HttpPut("actualizar/{idEspecialidad}")]
        public async Task<IActionResult> UpdateEspecialidad(int idEspecialidad, EspecialidadDTO especialidad)
        {
            var _encontrado = await this._especialidadService.Get(idEspecialidad);
            if (_encontrado != null)
            {
                especialidad.IdEspecialidad = _encontrado.IdEspecialidad;
                await this._especialidadService.Update(especialidad);
                return Ok(new { Success = "Actualizado exitoso" });
            }

            else return NotFound();
            //eliminar
        }
        [HttpDelete("eliminar/{idEspecialidad}")]
        public async Task<IActionResult> DeletePaciente(int idEspecialidad)
        {
            var _encontrado = await this._especialidadService.Get(idEspecialidad);
            if (_encontrado != null)
            {
                await this._especialidadService.Delete(idEspecialidad);
                return Ok(new { Success = "Eliminado exitoso" });
            }

            else return NotFound();
        }
    }
}
