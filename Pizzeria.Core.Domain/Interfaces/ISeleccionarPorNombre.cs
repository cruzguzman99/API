using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Domain.Interfaces
{
    public interface ISeleccionarPorNombre<TEntidad, TEntidadNombre>
    {
        TEntidad SeleccionarPorNombre(string entidad);
    }
}
