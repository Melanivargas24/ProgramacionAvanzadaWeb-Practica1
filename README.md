# Práctica Programada 1
Desarrollo de una API REST para una empresa dedicada a la compra y venta de automóviles, con el objetivo de facilitar la gestión de su catálogo de vehículos. Esta API permite realizar operaciones CRUD (crear, leer, actualizar y eliminar) sobre los registros de vehículos disponibles en el sistema. Entre sus funcionalidades se incluyen: el listado completo de vehículos registrados, la consulta del detalle de un vehículo específico, el registro de nuevos vehículos, la modificación de datos existentes y la eliminación de vehículos del catálogo. 

## Integrantes del equipo
- Erick Esteban Aguilar Villalobos
- Ariel Solís Bermúdez
- Melani Tamar Vargas Arrieta
- Esteban Vargas Vargas

## Especificaciones básicas

**a. Arquitectura del proyecto:**

Controllers: Contiene el controlador `VehiculoController.cs`, que se encarga de manejar las peticiones HTTP relacionadas con el modelo Vehiculo.
Models: Contiene la clase `Vehiculo.cs`, que representa la estructura de datos.
Program.cs: Configura la aplicación, los servicios y el pipeline de ejecución.


**b. Principios SOLID implementados:**

- S (Single Responsibility Principle): La clase Vehiculo solo representa datos, y VehiculoController solo maneja las peticiones relacionadas. Cada clase tiene una única responsabilidad clara.
- O (Open/Closed Principle): La arquitectura permite extender funcionalidades (como agregar más validaciones) sin modificar las existentes.
