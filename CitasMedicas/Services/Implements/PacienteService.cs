using AutoMapper;
using CitasMedicas.Data;
using CitasMedicas.DTOs;
using CitasMedicas.Models;
using CitasMedicas.Services.Interfaces;
using Dapper;
using System.Data;

namespace CitasMedicas.Services.Implements
{
    public class PacienteService : IPacienteService
    {
        private readonly DapperDBContext _dbContext;
        private IMapper _mapper;
        public PacienteService(DapperDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        //obtener variable 
        public async Task<List<PacienteDTO>> GetList()
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var pacienteList = await connection.QueryAsync<Paciente>("ObtenerPacienteDTO");
                return _mapper.Map<List<PacienteDTO>>(pacienteList);
            }
        }
        //obtener paciente por Id

        public async Task<PacienteDTO> Get(int idPaciente)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var paciente = await connection.QueryFirstOrDefaultAsync<Paciente>("ObtenerPacienteConEspecialidadPorId", new { idPaciente }, commandType: CommandType.StoredProcedure);
                return _mapper.Map<PacienteDTO>(paciente);
            }
        }

        public async Task<PacienteDTO> Add(PacienteDTO modelo)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                Paciente _modelo = _mapper.Map<Paciente>(modelo);
                await connection.ExecuteAsync("CrearPaciente", new { _modelo.NombreCompleto, _modelo.IdEspecialidad, _modelo.Telefono, _modelo.FechaCita });

                return _mapper.Map<PacienteDTO>(modelo);
            }
        }

        public async Task<bool> Update(PacienteDTO modelo)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    Paciente _modelo = _mapper.Map<Paciente>(modelo);
                    await connection.ExecuteAsync("EditarPaciente", new { _modelo.IdPaciente, _modelo.NombreCompleto, _modelo.IdEspecialidad, modelo.Telefono, _modelo.FechaCita }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> Delete(int idPaciente)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    await connection.ExecuteAsync("EliminarPaciente", new { idPaciente }, commandType: CommandType.StoredProcedure);

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
