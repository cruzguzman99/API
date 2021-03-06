using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Application.Interfaces;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Application.UseCases
{
    public class RootUseCase : INameUseCase<Root, Guid, String>
    {
        private readonly IRepositorioNombre<Root, Guid, String> repositorio;

        public RootUseCase(IRepositorioNombre<Root, Guid, String> _repositorio)
        {
            repositorio = _repositorio;
        }

        public Root Agregar(Root entidad)
        {
            if (entidad != null)
            {
                var resultado = repositorio.Agregar(entidad);
                repositorio.GuardarTodosLosCambios();
                return resultado;
            }
            else
            {
                throw new Exception("La entidad no puede ser nula");
            }
        }

        public void Editar(Root entidad)
        {
            repositorio.Editar(entidad);
            repositorio.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repositorio.Eliminar(entidadId);
            repositorio.GuardarTodosLosCambios();
        }

        public void GuardarTodosLosCambios()
        {
            repositorio.GuardarTodosLosCambios();
        }

        public List<Root> Listar()
        {
            return repositorio.Listar();
        }

        public Root SeleccionarPorID(Guid entidadId)
        {
            return repositorio.SeleccionarPorID(entidadId);
        }

        public Root SeleccionarPorNombre(string entidad)
        {
            return repositorio.SeleccionarPorNombre(entidad);
        }
    }
}
