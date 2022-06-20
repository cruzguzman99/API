using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Application.Interfaces;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Application.UseCases
{
    public class CategoriaUseCase : INameUseCase<Categoria, Guid, String>
	{

		private readonly IRepositorioNombre<Categoria, Guid, String> repositorio;

		public CategoriaUseCase(IRepositorioNombre<Categoria, Guid, String> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Categoria Agregar(Categoria entidad)
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

		public List<Categoria> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Categoria entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Categoria SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public Categoria SeleccionarPorNombre(string entidad)
		{
			return repositorio.SeleccionarPorNombre(entidad);
		}

		public void GuardarTodosLosCambios()
		{
			repositorio.GuardarTodosLosCambios();
		}
	}

}
