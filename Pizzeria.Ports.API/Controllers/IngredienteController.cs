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
	public class IngredienteController : ControllerBase
	{

		public IngredienteUseCase CrearServicio()
		{
			PizzeriaDB db = new PizzeriaDB();
			IngredienteRepository repositorio = new IngredienteRepository(db);

			IngredienteUseCase servicio = new IngredienteUseCase(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Ingrediente>> Get()
		{
			IngredienteUseCase servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Ingrediente> Get(Guid id)
		{
			IngredienteUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[HttpGet("Selecionar/{id}")]
		public ActionResult<String> Get(string id)
		{
			IngredienteUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorNombre(id));
		}


		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<String> Post([FromBody] Ingrediente Entidad)
		{
			try
			{
				IngredienteUseCase servicio = CrearServicio();

				var resultado = servicio.Agregar(Entidad);

				return Ok("success");
			}
			catch (Exception e)
			{
				return BadRequest("error");
			}
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult<String> Put(Guid id, [FromBody] Ingrediente Entidad)
		{
			try
			{
				IngredienteUseCase servicio = CrearServicio();

				Entidad.IngredienteID = id;

				servicio.Editar(Entidad);

				return Ok("success");
			}
			catch (Exception e)
			{
				return BadRequest("error");
			}

		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			IngredienteUseCase servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
