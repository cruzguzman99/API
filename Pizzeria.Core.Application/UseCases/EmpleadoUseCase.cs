using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Application.Interfaces;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Application.UseCases
{
    public class EmpleadoUseCase : INameUseCase<Empleado, Guid, String>
	{

		private readonly IRepositorioNombre<Empleado, Guid, String> repositorio;

		public EmpleadoUseCase(IRepositorioNombre<Empleado, Guid, String> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Empleado Agregar(Empleado entidad)
		{
			if (entidad != null)
			{
				var resultado = repositorio.Agregar(entidad);
				repositorio.GuardarTodosLosCambios();
				return resultado;
			}
			else
				throw new Exception("Error la entidad no puede ser nula");
		}

		public List<Empleado> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Empleado entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Empleado SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public Empleado SeleccionarPorNombre(string entidad)
		{
			return repositorio.SeleccionarPorNombre(entidad);
		}

		public void GuardarTodosLosCambios()
		{
			repositorio.GuardarTodosLosCambios();
		}
	}
  
}
