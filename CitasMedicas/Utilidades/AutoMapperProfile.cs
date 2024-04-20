using AutoMapper;
using CitasMedicas.DTOs;
using CitasMedicas.Models;
using System.Globalization;

namespace CitasMedicas.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Especialidad, EspecialidadDTO>().ReverseMap();
            CreateMap<Paciente, PacienteDTO>()
                .ForMember(destino => destino.FechaCita,
                opt => opt.MapFrom(origen => origen.FechaCita.Value.ToString("dd/MM/yyyy")));
            CreateMap<PacienteDTO, Paciente>()
                .ForMember(destino =>
                destino.FechaCita,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaCita, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
