using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Application.Interfaces;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Application.UseCases
{
    public class IngredienteUseCase : INameUseCase<Ingrediente, Guid, String>
	{

		private readonly IRepositorioNombre<Ingrediente, Guid, String> repositorio;

		public IngredienteUseCase(IRepositorioNombre<Ingrediente, Guid, String> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Ingrediente Agregar(Ingrediente entidad)
		{
			if (entidad != null)
			{
				var resultado = repositorio.Agregar(entidad);
				if (resultado.Nombre == "" || resultado.precio == 0 || resultado.Stock == 0 || resultado.unidadMedida == "")
				{
					throw new Exception("error");
				}
				repositorio.GuardarTodosLosCambios();
				return resultado;
			}
			else
				throw new Exception("Error la entidad no puede ser nula");
		}

		public List<Ingrediente> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Ingrediente entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Ingrediente SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public Ingrediente SeleccionarPorNombre(string entidad)
		{
			return repositorio.SeleccionarPorNombre(entidad);
		}

		public void GuardarTodosLosCambios()
		{
			repositorio.GuardarTodosLosCambios();

		}
	}
}
