﻿using Microsoft.AspNetCore.Mvc;
using Practica1.Models;


namespace Practica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {

        private static List<Vehiculo> vehiculos = new List<Vehiculo>
        {
            new Vehiculo { Marca = "Nissan", Modelo = "Versa", Anio = 2023, Color="Rojo", Precio = 20000000 },
            new Vehiculo { Marca = "KIA", Modelo = "Sorento", Anio = 2012, Color="Negro", Precio = 9000000 },

        };

        //Listado de vehículos

        [HttpGet("GetVehiculos")]
        public ActionResult GetVehiculos()
        {
            return Ok(vehiculos);
        }

        //Ver el detalle del vehículo según la marca

        [HttpGet("GetVehiculo")]
        public ActionResult GetVehiculo(string marca)
        {
            var vehiculoEspecifico = vehiculos.Find(x => x.Marca == marca);

            return Ok(vehiculoEspecifico);
        }

        // POST api/<VehiculoController>
        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                return BadRequest("El vehículo no puede ser nulo");
            }

            if (string.IsNullOrEmpty(vehiculo.Marca) || string.IsNullOrEmpty(vehiculo.Modelo))
            {
                return BadRequest("La marca y el modelo son requeridos");
            }

            vehiculos.Add(vehiculo);
            return CreatedAtAction(nameof(GetVehiculo), new { marca = vehiculo.Marca }, vehiculo);
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
