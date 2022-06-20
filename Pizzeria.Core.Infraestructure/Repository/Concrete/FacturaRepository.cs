using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Infraestructure.Repository.Concrete
{
    public class FacturaRepository : IRepositorioMovimiento<Factura, Guid>
	{

		private PizzeriaDB db;

		public FacturaRepository(PizzeriaDB _db)
		{
			db = _db;
		}

		public Factura Agregar(Factura Entidad)
		{
			Entidad.FacturaID = Guid.NewGuid();

			db.Factura.Add(Entidad);

			return Entidad;
		}

		public List<Factura> Listar()
		{
			return db.Factura.ToList();
		}

		public Factura SeleccionarPorID(Guid entidadId)

		{
			var EntidadSeleccionado = db.Factura.Where(c => c.FacturaID == entidadId).FirstOrDefault();
			return EntidadSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

		public void Anular(Guid entidadId)
		{
			var ventaSeleccionada = SeleccionarPorID(entidadId);

			if (ventaSeleccionada != null)
			{
				ventaSeleccionada.anulado = true;

				db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
			else
			{
				throw new NullReferenceException("No se ha encontrado la venta que intenta anular... 😣");
			}
		}
	}
}
