using CitasMedicas.DTOs;

namespace CitasMedicas.Services.Interfaces
{
    public interface IEspecialidadService
    {
        Task<List<EspecialidadDTO>> GetList();
        Task<EspecialidadDTO> Get(int idEspecialidad);
        Task<EspecialidadDTO> Add(EspecialidadDTO modelo);
        Task<bool> Update(EspecialidadDTO modelo);
        Task<bool> Delete(int idEspecialidad);
    }
}
