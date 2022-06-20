﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Infraestructure.Repository.Concrete
{
    public class EmpleadoRepository : IRepositorioNombre<Empleado, Guid, String>
	{

		private PizzeriaDB db;

		public EmpleadoRepository(PizzeriaDB _db)
		{
			db = _db;
		}

		public Empleado Agregar(Empleado Entidad)
		{
			Entidad.EmpleadoID = Guid.NewGuid();

			db.Empleado.Add(Entidad);

			return Entidad;
		}

		public List<Empleado> Listar()
		{
			return db.Empleado.ToList();
		}

		public void Editar(Empleado Entidad)
		{
			var EntidadSeleccionada = db.Empleado.Where(c => c.EmpleadoID == Entidad.EmpleadoID).FirstOrDefault();
			if (EntidadSeleccionada != null)
			{
				EntidadSeleccionada.Nombre = Entidad.Nombre;
				EntidadSeleccionada.Apellido = Entidad.Apellido;
				EntidadSeleccionada.Contraseña = Entidad.Contraseña;
				EntidadSeleccionada.Correo = Entidad.Correo;

				db.Entry(EntidadSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var EntidadSeleccionado = db.Empleado.Where(c => c.EmpleadoID == entidadId).FirstOrDefault();
			if (EntidadSeleccionado != null)
			{
				db.Empleado.Remove(EntidadSeleccionado);
			}
		}

		public Empleado SeleccionarPorID(Guid entidadId)

		{
			var EntidadSeleccionado = db.Empleado.Where(c => c.EmpleadoID == entidadId).FirstOrDefault();
			return EntidadSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

		public Empleado SeleccionarPorNombre(string entidad)
		{
			var EntidadSeleccionado = db.Empleado.Where(c => c.Nombre == entidad).FirstOrDefault();
			return EntidadSeleccionado;
		}
	}
}
