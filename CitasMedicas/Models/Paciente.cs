namespace CitasMedicas.Models
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string? NombreCompleto { get; set; }
        public int? IdEspecialidad { get; set; }
        public string? NombreEspecialidad { get; set; }
        public int? Telefono { get; set; }
        public DateTime? FechaCita { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
