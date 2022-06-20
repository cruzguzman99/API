using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Infraestructure.Repository.Concrete
{
    public class CrearProductoRepository : IRepositorioBase<CrearProducto, Guid>
	{

		private PizzeriaDB db;

		public CrearProductoRepository(PizzeriaDB _db)
		{
			db = _db;
		}

		public CrearProducto Agregar(CrearProducto Entidad)
		{
			Entidad.CrearProductoID = Guid.NewGuid();

			db.CrearProducto.Add(Entidad);

			return Entidad;
		}

		public List<CrearProducto> Listar()
		{
			return db.CrearProducto.ToList();
		}

		public void Editar(CrearProducto Entidad)
		{
			var EntidadSeleccionada = db.CrearProducto.Where(c => c.CrearProductoID == Entidad.CrearProductoID).FirstOrDefault();
			if (EntidadSeleccionada != null)
			{
				EntidadSeleccionada.CantidadIngrediente = Entidad.CantidadIngrediente;
				EntidadSeleccionada.CostoDeIngredientes = Entidad.CostoDeIngredientes;
				EntidadSeleccionada.IngredienteID = Entidad.IngredienteID;
				EntidadSeleccionada.ProductoID = Entidad.ProductoID;


				db.Entry(EntidadSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var EntidadSeleccionado = db.CrearProducto.Where(c => c.CrearProductoID == entidadId).FirstOrDefault();
			if (EntidadSeleccionado != null)
			{
				db.CrearProducto.Remove(EntidadSeleccionado);
			}
		}

		public CrearProducto SeleccionarPorID(Guid entidadId)

		{
			var EntidadSeleccionado = db.CrearProducto.Where(c => c.CrearProductoID == entidadId).FirstOrDefault();
			return EntidadSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

		public List<CrearProducto> SeleccionarDetallesPorMovimiento(Guid EntidadID)
		{
			return db.CrearProducto.Where(c => c.ProductoID == EntidadID).ToList();
		}
	}
}
