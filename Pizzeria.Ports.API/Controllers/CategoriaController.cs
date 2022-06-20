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
	public class CategoriaController : ControllerBase
	{

		public CategoriaUseCase CrearServicio()
		{
			PizzeriaDB db = new PizzeriaDB();
			CategoriaRepository repositorio = new CategoriaRepository(db);

			CategoriaUseCase servicio = new CategoriaUseCase(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Categoria>> Get()
		{
			CategoriaUseCase servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Categoria> Get(Guid id)
		{
			CategoriaUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[HttpGet("Selecionar/{id}")]
		public ActionResult<String> Get(string id)
		{
			CategoriaUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorNombre(id));
		}

		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Categoria> Post([FromBody] Categoria Entidad)
		{
			CategoriaUseCase servicio = CrearServicio();

			var resultado = servicio.Agregar(Entidad);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Categoria Entidad)
		{
			CategoriaUseCase servicio = CrearServicio();

			Entidad.CategoriaID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			CategoriaUseCase servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
