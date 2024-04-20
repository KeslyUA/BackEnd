namespace CitasMedicas.DTOs
{
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }
        public string? NombreCompleto { get; set; }
        public int? IdEspecialidad { get; set; }
        public string? NombreEspecialista { get; set; }
        public int? Telefono { get; set; }
        public string? FechaCita { get; set; }

    }
}
