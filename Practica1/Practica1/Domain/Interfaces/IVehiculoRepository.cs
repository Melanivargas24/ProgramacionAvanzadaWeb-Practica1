using Practica1.Domain.Entities;

namespace Practica1.Domain.Interfaces
{
    public interface IVehiculoRepository
    {
        IEnumerable<Vehiculo> GetVehiculos();
        Vehiculo? GetVehiculo(string marca);
        Vehiculo? AddVehiculo(Vehiculo vehiculo);
        Vehiculo? UpdateVehiculo(int id, Vehiculo vehiculo);
        bool DeleteVehiculo(int id);
    }
}
