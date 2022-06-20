using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;

namespace Pizzeria.Core.Infraestructure.Repository.Concrete
{
    public class AdministradorRepository : IRepositorioNombre<Administrador, Guid, String>
    {

        private PizzeriaDB db;

        public AdministradorRepository(PizzeriaDB _db)
        {
            db = _db;
        }

        public Administrador Agregar(Administrador entidad)
        {
            entidad.AdministradoID = Guid.NewGuid();

            db.Administrador.Add(entidad);

            return entidad;
        }

        public void Editar(Administrador entidad)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.AdministradoID == entidad.AdministradoID).FirstOrDefault();
            if (AdministradorSeleccionado != null)
            {
                AdministradorSeleccionado.Nombre = entidad.Nombre;
                AdministradorSeleccionado.Apellido = entidad.Apellido;
                AdministradorSeleccionado.Contraseña = entidad.Contraseña;

                db.Entry(AdministradorSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.AdministradoID == entidadId).FirstOrDefault();
            if (AdministradorSeleccionado != null)
            {
                db.Administrador.Remove(AdministradorSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Administrador> Listar()
        {
            return db.Administrador.ToList();
        }

        public Administrador SeleccionarPorID(Guid entidadId)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.AdministradoID == entidadId).FirstOrDefault();
            return AdministradorSeleccionado;
        }

        public Administrador SeleccionarPorNombre(string entidad)
        {
            var AdministradorSeleccionado = db.Administrador.Where(c => c.Nombre == entidad).FirstOrDefault();
            return AdministradorSeleccionado;
        }
    }
}
