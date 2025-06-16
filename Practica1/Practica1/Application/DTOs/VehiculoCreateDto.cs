namespace Practica1.Application.DTOs
{
    public class VehiculoCreateDto
    {
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Anio { get; set; }
        public string Color { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
