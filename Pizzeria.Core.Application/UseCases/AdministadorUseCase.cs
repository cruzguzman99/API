using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Application.Interfaces;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Core.Infraestructure.Repository.Abstract;

namespace Pizzeria.Core.Application.UseCases
{
    public class AdministadorUseCase : INameUseCase<Administrador, Guid, String>
    {

        private readonly IRepositorioNombre<Administrador, Guid, String> repositorio;

        public AdministadorUseCase(IRepositorioNombre<Administrador, Guid, String> _repositorio)
        {
            repositorio = _repositorio;
        }

        public Administrador Agregar(Administrador entidad)
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

        public void Editar(Administrador entidad)
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

        public List<Administrador> Listar()
        {
            return repositorio.Listar();
        }

        public Administrador SeleccionarPorID(Guid entidadId)
        {
            return repositorio.SeleccionarPorID(entidadId);
        }

        public Administrador SeleccionarPorNombre(string entidad)
        {
            return repositorio.SeleccionarPorNombre(entidad);
        }
    }
}
