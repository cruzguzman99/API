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
	public class ProductoController : ControllerBase
	{
		private List<Producto> _Producto;
		public ProductoUseCase CrearServicio()
		{
			PizzeriaDB db = new PizzeriaDB();
			IngredienteRepository repositorioIngrediente = new IngredienteRepository(db);
			ProductoRepository repositorioProducto = new ProductoRepository(db);
			CrearProductoRepository repositorioCrearProducto = new CrearProductoRepository(db);
			ProductoUseCase servicio = new ProductoUseCase(repositorioProducto, repositorioCrearProducto, repositorioIngrediente);

			return servicio;
		}

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Producto>> Get()
		{
			ProductoUseCase servicio = CrearServicio();

			return Ok(servicio.Listar());
		}

		[HttpGet("Seleccionar/PorNombre/{id}")]
		public ActionResult<String> GetProducto(string id)
		{
			ProductoUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorNombre(id));
		}

		[HttpGet("Selecionar/Producto/{buscar}")]
		public ActionResult<String> Get(string buscar)
		{
			PizzeriaDB context = new PizzeriaDB();
			try
			{

				_Producto = context.Producto.ToList();
				//var SeleccionarProducto = context.Producto.Where(s => s.IdCategoria == id).ToList();
				if (!string.IsNullOrEmpty(buscar))
				{
					foreach (var item in buscar.Split(new char[] { ' ' },
							 StringSplitOptions.RemoveEmptyEntries))
					{
						_Producto = _Producto.Where(x => x.Nombre.Contains(item)).ToList();

					};
				}
				var resultado = _Producto.Join(context.Categoria,
							Producto => Producto.CategoriaID,
							Categoria => Categoria.CategoriaID,
							(Producto, Categoria) => new
							{
								Categoria = Categoria.Nombre,
								CategoriaID = Producto.CategoriaID,
								Nombre = Producto.Nombre,
								ProductoID = Producto.ProductoID,
								Imagen = Producto.Imagen,
								Precio = Producto.Precio,
								Tamaño = Producto.Tamaño,
								Ingrediente = (from cp in context.CrearProducto
											   join p in context.Producto on cp.ProductoID equals p.ProductoID
											   join i in context.Ingredientes on cp.IngredienteID equals i.IngredienteID
											   where cp.ProductoID == Producto.ProductoID
											   select new
											   {
												   IngredienteID = i.IngredienteID,
												   Ingrediente = i.Nombre,
												   CantidadIngrediente = cp.CantidadIngrediente,
												   crearProducto = cp.CrearProductoID,
											   }).ToList()

							}
						).ToList();
				return Ok(resultado);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Producto> Get(Guid id)
		{
			ProductoUseCase servicio = CrearServicio();

			return Ok(servicio.SeleccionarPorID(id));
		}

		[HttpGet("Seleccionar/{id}")]
		public ActionResult GetCategoria(String id)
		{
			PizzeriaDB context = new PizzeriaDB();
			try
			{

				//var SeleccionarProducto = context.Producto.Where(s => s.IdCategoria == id).ToList();
				var SeleccionarProducto = (from c in context.Categoria
										   join pd in context.Producto on c.CategoriaID equals pd.CategoriaID
										   where c.Nombre == id
										   select new
										   {
											   Categoria = c.Nombre,
											   CategoriaID = c.CategoriaID,
											   Nombre = pd.Nombre,
											   ProductoID = pd.ProductoID,
											   Imagen = pd.Imagen,
											   Precio = pd.Precio,
											   Tamaño = pd.Tamaño,
											   Stock = pd.Stock,
											   Descripcion = pd.Descripcion,
											   isCompound = pd.isCompound,
											   Ingrediente = (from cp in context.CrearProducto
															  join p in context.Producto on cp.ProductoID equals p.ProductoID
															  join i in context.Ingredientes on cp.IngredienteID equals i.IngredienteID
															  where cp.ProductoID == pd.ProductoID
															  select new
															  {
																  IngredienteID = i.IngredienteID,
																  Ingrediente = i.Nombre,
																  CantidadIngrediente = cp.CantidadIngrediente,
																  crearProducto = cp.CrearProductoID,
															  }).ToList()
										   }).ToList();
				return Ok(SeleccionarProducto);
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}

		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<String> Post([FromBody] Producto Entidad)
		{
			try
			{
				var base64array = Convert.FromBase64String(Entidad.Imagen);
				Guid name = Guid.NewGuid();
				string filePashString = $"Content/img/{name}.png";

				var filePath = Path.Combine($"Content/img/{name}.png");
				System.IO.File.WriteAllBytes(filePath, base64array);

				ProductoUseCase servicio = CrearServicio();
				Entidad.Imagen = filePashString;
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
		public ActionResult Put(Guid id, [FromBody] Producto Entidad)
		{
			ProductoUseCase servicio = CrearServicio();

			Entidad.ProductoID = id;

			servicio.Editar(Entidad);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id)
		{
			ProductoUseCase servicio = CrearServicio();

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
