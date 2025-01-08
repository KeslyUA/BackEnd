using AutoMapper;
using Dapper;
using CitasMedicas.Data;
using CitasMedicas.DTOs;
using CitasMedicas.Models;
using CitasMedicas.Services.Interfaces;
using System.Data;

namespace CitasMedicas.Services.Implements
{               //interactua con la base de datos get,add,update,delete
    public class EspecialidadService : IEspecialidadService
    {
        private readonly DapperDBContext _dbContext;
        private IMapper _mapper;
        public EspecialidadService(DapperDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EspecialidadDTO>> GetList()
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var dptoList = await connection.QueryAsync<Especialidad>("ObtenerEspecialidad");
                dptoList = dptoList.ToList();
                return _mapper.Map<List<EspecialidadDTO>>(dptoList);
            }
        }
        //listar paciente por ID

        public async Task<EspecialidadDTO> Get(int idEspecialidad)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var dpto = await connection.QueryFirstOrDefaultAsync<EspecialidadDTO>("ObtenerespecialidadPorId", new { idEspecialidad }, commandType: CommandType.StoredProcedure);
                return dpto;
            }
        }
        //crear nuevo Especializacion de la clinica

        public async Task<EspecialidadDTO> Add(EspecialidadDTO modelo)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                Especialidad _modelo = _mapper.Map<Especialidad>(modelo);
                await connection.ExecuteAsync("CrearEspecialidad", new { _modelo.Nombre });

                return _mapper.Map<EspecialidadDTO>(modelo);
            }
        }
        //editar especialidad de la clinica

        public async Task<bool> Update(EspecialidadDTO modelo)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    Especialidad _modelo = _mapper.Map<Especialidad>(modelo);
                    await connection.ExecuteAsync("EditarEspecialidad", new { _modelo.IdEspecialidad, _modelo.Nombre }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //eliminar especialidad
        public async Task<bool> Delete(int idEspecialidad)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    await connection.ExecuteAsync("Eliminarespecialidad", new { idEspecialidad }, commandType: CommandType.StoredProcedure);

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
