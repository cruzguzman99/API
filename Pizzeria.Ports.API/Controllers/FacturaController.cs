using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;
using Pizzeria.Core.Application.UseCases;
using Pizzeria.Core.Infraestructure.Repository.Concrete;
using Pizzeria.Core.Domain.Models;
using Microsoft.AspNetCore.Cors;
using System.IO;

namespace Pizzeria.Ports.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacturaController : ControllerBase
	{

		public FacturaUseCase CrearServicio()
		{
			PizzeriaDB db = new PizzeriaDB();
			IngredienteRepository repositorioIngrediente = new IngredienteRepository(db);
			FacturaDetalleRepository repositorioFacturaDetalle = new FacturaDetalleRepository(db);
			FacturaRepository repositorioFactura = new FacturaRepository(db);
			ProductoRepository repositorioProducto = new ProductoRepository(db);
			CrearProductoRepository repositorioCrearProducto = new CrearProductoRepository(db);
			FacturaUseCase servicio = new FacturaUseCase(repositorioFactura, repositorioFacturaDetalle, repositorioProducto, repositorioIngrediente, repositorioCrearProducto);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Factura>> Get()
		{
			FacturaUseCase servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Factura> Get(Guid id)
		{
			FacturaUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Factura> Post([FromBody] Factura Entidad)
		{
			FacturaUseCase servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);

			return Ok(new Factura()
			{
				ClienteID = resultado.ClienteID,
				EmpleadoID = resultado.EmpleadoID,
				FacturaID = resultado.FacturaID,
				Fecha = resultado.Fecha,
				Total = resultado.Total,
			});
		}


		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			FacturaUseCase servicio = CrearServicio();

			servicio.Anular(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
