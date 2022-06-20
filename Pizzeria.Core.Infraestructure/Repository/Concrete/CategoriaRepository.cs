using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;

namespace Pizzeria.Core.Infraestructure.Repository.Concrete
{
    public class CategoriaRepository : IRepositorioNombre<Categoria, Guid, String>
	{

		private PizzeriaDB db;

		public CategoriaRepository(PizzeriaDB _db)
		{
			db = _db;
		}

		public Categoria Agregar(Categoria Categoria)
		{
			Categoria.CategoriaID = Guid.NewGuid();

			db.Categoria.Add(Categoria);

			return Categoria;
		}

		public List<Categoria> Listar()
		{
			return db.Categoria.ToList();
		}

		public void Editar(Categoria Categoria)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == Categoria.CategoriaID).FirstOrDefault();
			if (CategoriaSeleccionado != null)
			{
				CategoriaSeleccionado.Nombre = Categoria.Nombre;
				CategoriaSeleccionado.Descripcion = Categoria.Descripcion;

				db.Entry(CategoriaSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == entidadId).FirstOrDefault();
			if (CategoriaSeleccionado != null)
			{
				db.Categoria.Remove(CategoriaSeleccionado);
			}
		}

		public Categoria SeleccionarPorID(Guid entidadId)

		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == entidadId).FirstOrDefault();
			return CategoriaSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

		public Categoria SeleccionarPorNombre(string entidad)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.Nombre == entidad).FirstOrDefault();
			return CategoriaSeleccionado;
		}
	}
}
