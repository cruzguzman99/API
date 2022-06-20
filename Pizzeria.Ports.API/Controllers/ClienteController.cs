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
	public class ClienteController : ControllerBase
	{

		public ClienteUseCase CrearServicio()
		{
			PizzeriaDB db = new PizzeriaDB();
			ClienteRepository repositorio = new ClienteRepository(db);

			ClienteUseCase servicio = new ClienteUseCase(repositorio);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Cliente>> Get()
		{
			ClienteUseCase servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Cliente> Get(Guid id)
		{

			ClienteUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[HttpGet("Seleccionar/{correo}/{contraseña}")]
		public ActionResult<Cliente> GetSelect(string correo, string contraseña)
		{
			try
			{
				PizzeriaDB db = new PizzeriaDB();
				var ClienteSeleccionado = db.Clientes.Where(c => c.Correo == correo).Where(c => c.Contraseña == contraseña).FirstOrDefault();
				ClienteUseCase servicio = CrearServicio();

				return Ok(servicio.SeleccionarPorID(ClienteSeleccionado.ClienteID));
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}

		}
		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Cliente> Post([FromBody] Cliente cliente)
		{

			var base64array = Convert.FromBase64String(cliente.Imagen);
			Guid name = Guid.NewGuid();
			string filePashString = $"Content/img/{name}.png";

			var filePath = Path.Combine($"Content/img/{name}.png");
			System.IO.File.WriteAllBytes(filePath, base64array);

			ClienteUseCase servicio = CrearServicio();
			cliente.Imagen = filePashString;
			var resultado = servicio.Agregar(cliente);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Cliente Entidad)
		{
			ClienteUseCase servicio = CrearServicio();

			Entidad.ClienteID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			ClienteUseCase servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
