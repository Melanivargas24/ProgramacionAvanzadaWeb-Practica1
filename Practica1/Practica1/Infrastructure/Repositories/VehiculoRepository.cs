using Practica1.Domain.Entities;
using Practica1.Domain.Interfaces;

namespace Practica1.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private static List<Vehiculo> vehiculos = new List<Vehiculo>
        {
            new Vehiculo { Id = 1, Marca = "Nissan", Modelo = "Versa", Anio = 2023, Color="Rojo", Precio = 20000000 },
            new Vehiculo { Id = 2, Marca = "KIA", Modelo = "Sorento", Anio = 2012, Color="Negro", Precio = 9000000 },
            new Vehiculo { Id = 3, Marca = "Toyota", Modelo = "Corolla", Anio = 2020, Color="Blanco", Precio = 15000000 },
            new Vehiculo { Id = 4, Marca = "Chevrolet", Modelo = "Tracker", Anio = 2021, Color="Azul", Precio = 18000000 },
            new Vehiculo { Id = 5, Marca = "Ford", Modelo = "Focus", Anio = 2019, Color="Gris", Precio = 16000000 }
        };

        // Obtener todos los vehículos
        public IEnumerable<Vehiculo> GetVehiculos() => vehiculos;

        // Obtener un vehículo por marca
        public Vehiculo? GetVehiculo(string marca) =>
            vehiculos.FirstOrDefault(v => v.Marca.Equals(marca, StringComparison.OrdinalIgnoreCase));

        // Agregar un nuevo vehículo
        public Vehiculo? AddVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null || string.IsNullOrEmpty(vehiculo.Marca) || string.IsNullOrEmpty(vehiculo.Modelo))
                return null;

            vehiculo.Id = vehiculos.Max(v => v.Id) + 1; // Asignar nuevo ID automáticamente
            vehiculos.Add(vehiculo);
            return vehiculo;
        }

        // Actualizar un vehículo existente
        public Vehiculo? UpdateVehiculo(int id, Vehiculo vehiculo)
        {
            var existente = vehiculos.FirstOrDefault(v => v.Id == id);
            if (existente == null)
                return null;

            existente.Marca = vehiculo.Marca;
            existente.Modelo = vehiculo.Modelo;
            existente.Anio = vehiculo.Anio;
            existente.Color = vehiculo.Color;
            existente.Precio = vehiculo.Precio;

            return existente;
        }

        // Eliminar un vehículo por ID
        public bool DeleteVehiculo(int id)
        {
            var vehiculo = vehiculos.FirstOrDefault(v => v.Id == id);
            if (vehiculo == null)
                return false;

            vehiculos.Remove(vehiculo);
            return true;
        }
    }
}
