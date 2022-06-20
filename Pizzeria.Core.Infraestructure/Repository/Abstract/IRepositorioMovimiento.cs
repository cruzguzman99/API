using Pizzeria.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Infraestructure.Repository.Abstract
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID entidadId);

    }
}
