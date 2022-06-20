using Pizzeria.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Infraestructure.Repository.Abstract
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
         : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion, ISeleccionarDetallePorMovimento<TEntidad, TEntidadID>
    {

    }
}
