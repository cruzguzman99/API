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
	public class EmpleadoController : ControllerBase
	{

		public EmpleadoUseCase CrearServicio()
		{
			PizzeriaDB db = new PizzeriaDB();
			EmpleadoRepository repositorio = new EmpleadoRepository(db);

			EmpleadoUseCase servicio = new EmpleadoUseCase(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Empleado>> Get()
		{
			EmpleadoUseCase servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Empleado> Get(Guid id)
		{
			EmpleadoUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}


		[HttpGet("Seleccionar/{correo}/{contraseña}")]
		public ActionResult<Empleado> GetSelect(string correo, string contraseña)
		{
			try
			{
				PizzeriaDB db = new PizzeriaDB();
				var EmpleadoSeleccionado = db.Empleado.Where(c => c.Correo == correo).Where(c => c.Contraseña == contraseña).FirstOrDefault();
				EmpleadoUseCase servicio = CrearServicio();

				return Ok(servicio.SeleccionarPorID(EmpleadoSeleccionado.EmpleadoID));
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}

		}
		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Empleado> Post([FromBody] Empleado Entidad)
		{
			var base64array = Convert.FromBase64String(Entidad.Imagen);
			Guid name = Guid.NewGuid();
			string filePashString = $"Content/img/{name}.png";

			var filePath = Path.Combine($"Content/img/{name}.png");
			System.IO.File.WriteAllBytes(filePath, base64array);

			EmpleadoUseCase servicio = CrearServicio();
			Entidad.Imagen = filePashString;
			var resultado = servicio.Agregar(Entidad);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Empleado Entidad)
		{
			EmpleadoUseCase servicio = CrearServicio();

			Entidad.EmpleadoID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			EmpleadoUseCase servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
