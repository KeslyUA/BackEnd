using CitasMedicas.DTOs;

namespace CitasMedicas.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<List<PacienteDTO>> GetList();
        Task<PacienteDTO> Get(int idPaciente);
        Task<PacienteDTO> Add(PacienteDTO modelo);
        Task<bool> Update(PacienteDTO modelo);
        Task<bool> Delete(int idPaciente);
    }
}
