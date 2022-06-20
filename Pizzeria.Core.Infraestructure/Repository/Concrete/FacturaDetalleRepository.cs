using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Infraestructure.Repository.Concrete
{
    public class FacturaDetalleRepository : IRepositorioDetalle<FacturaDetalle, Guid>
    {

        private PizzeriaDB db;

        public FacturaDetalleRepository(PizzeriaDB _db)
        {
            db = _db;
        }

        public FacturaDetalle Agregar(FacturaDetalle entidad)
        {

            db.FacturaDetalle.Add(entidad);

            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<FacturaDetalle> SeleccionarDetallesPorMovimiento(Guid movimientoId)
        {
            return db.FacturaDetalle.Where(c => c.FacturaID == movimientoId).ToList();
        }
    }

}
