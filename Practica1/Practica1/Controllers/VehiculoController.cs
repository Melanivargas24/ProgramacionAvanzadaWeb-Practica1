using Microsoft.AspNetCore.Mvc;
using Practica1.Application.DTOs;
using Practica1.Domain.Entities;
using Practica1.Domain.Interfaces;

namespace Practica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoRepository vehiculoRepository;

        public VehiculoController(IVehiculoRepository vehiculoRepository)
        {
            this.vehiculoRepository = vehiculoRepository;
        }

        //Listado de vehículos

        [HttpGet("GetVehiculos")]
        public ActionResult GetVehiculos()
        {
            var vehiculos = vehiculoRepository.GetVehiculos();

            if (vehiculos == null || !vehiculos.Any())
            {
                return NotFound("No se encontraron vehículos");
            }

            return Ok(vehiculos);
        }

        //Ver el detalle del vehículo según la marca

        [HttpGet("GetVehiculo")]
        public ActionResult GetVehiculo(string marca)
        {
            if (string.IsNullOrEmpty(marca))
            {
                return BadRequest("La marca es requerida");
            }

            var vehiculo = vehiculoRepository.GetVehiculo(marca);

            if (vehiculo == null)
            {
                return NotFound($"No se encontró un vehículo con la marca {marca}");
            }

            return Ok(vehiculo);
        }

        // POST api/<VehiculoController>
        [HttpPost]
        public ActionResult NewVehiculo([FromBody] VehiculoCreateDto vehiculo)
        {
            if (vehiculo == null)
            {
                return BadRequest("El vehículo no puede ser nulo");
            }

            if (string.IsNullOrEmpty(vehiculo.Marca) || string.IsNullOrEmpty(vehiculo.Modelo))
            {
                return BadRequest("La marca y el modelo son requeridos");
            }

            var nuevoVehiculo = new Vehiculo
            {
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                Color = vehiculo.Color,
                Precio = (int)vehiculo.Precio
            };

            var createdVehiculo = vehiculoRepository.AddVehiculo(nuevoVehiculo);

            if (createdVehiculo == null)
            {
                return BadRequest("No se pudo crear el vehículo. Verifique los datos proporcionados.");
            }

            return CreatedAtAction(nameof(GetVehiculo), new { marca = createdVehiculo.Marca }, createdVehiculo);
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateVehiculo(int id, [FromForm] VehiculoCreateDto vehiculo)
        {
            if (vehiculo == null)
            {
                return BadRequest("El vehículo no puede ser nulo");
            }

            if (string.IsNullOrEmpty(vehiculo.Marca) || string.IsNullOrEmpty(vehiculo.Modelo))
            {
                return BadRequest("La marca y el modelo son requeridos");
            }

            var actualizadoVehiculo = new Vehiculo
            {
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                Color = vehiculo.Color,
                Precio = (int)vehiculo.Precio
            };

            var updatedVehiculo = vehiculoRepository.UpdateVehiculo(id, actualizadoVehiculo);

            if (updatedVehiculo == null)
            {
                return NotFound($"No se encontró un vehículo con el ID {id}");
            }

            return Ok(updatedVehiculo);
        }

        // DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleted = vehiculoRepository.DeleteVehiculo(id);

            if (!deleted)
            {
                NotFound($"No se encontró un vehículo con el ID {id}");
            }
            else
            {
                Ok($"Vehículo con ID {id} eliminado correctamente");
            }
        }
    }
}
