using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Domain.Interfaces
{
    public interface ISeleccionarDetallePorMovimento<TEntidad, TMovimientoID>
    {
        List<TEntidad> SeleccionarDetallesPorMovimiento(TMovimientoID movimientoId);
    }
}
