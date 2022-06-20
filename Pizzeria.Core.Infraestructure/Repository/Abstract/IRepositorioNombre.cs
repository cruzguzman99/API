using Pizzeria.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Infraestructure.Repository.Abstract
{
    public interface IRepositorioNombre<TEntidad, TEntidadID, TEntidadNombre>
         : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ISeleccionarPorNombre<TEntidad, TEntidadNombre>, ITransaccion
    { }
}
