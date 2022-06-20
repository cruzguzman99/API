using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Infraestructure.Repository.Concrete
{
    public class RootRepository : IRepositorioNombre<Root, Guid, String>
    {

        private PizzeriaDB db;

        public RootRepository(PizzeriaDB _db)
        {
            db = _db;
        }

        public Root Agregar(Root entidad)
        {
            entidad.RootID = Guid.NewGuid();

            db.Root.Add(entidad);

            return entidad;
        }

        public void Editar(Root entidad)
        {
            var RootSeleccionado = db.Root.Where(c => c.RootID == entidad.RootID).FirstOrDefault();
            if (RootSeleccionado != null)
            {
                RootSeleccionado.Nombre = entidad.Nombre;
                RootSeleccionado.Apellido = entidad.Apellido;
                RootSeleccionado.Contraseña = entidad.Contraseña;


                db.Entry(RootSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var RootSeleccionado = db.Root.Where(c => c.RootID == entidadId).FirstOrDefault();
            if (RootSeleccionado != null)
            {
                db.Root.Remove(RootSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Root> Listar()
        {
            return db.Root.ToList();
        }

        public Root SeleccionarPorID(Guid entidadId)
        {
            var RootSeleccionado = db.Root.Where(c => c.RootID == entidadId).FirstOrDefault();
            return RootSeleccionado;
        }

        public Root SeleccionarPorNombre(string entidad)
        {
            var RootSeleccionado = db.Root.Where(c => c.Nombre == entidad).FirstOrDefault();
            return RootSeleccionado;
        }
    }
}
