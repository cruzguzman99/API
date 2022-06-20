using Pizzeria.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Infraestructure.Repository.Abstract
{
    public interface IRepositorioDetalle<TEntidad, TMovimientoID>
        : IAgregar<TEntidad>, ITransaccion
    {
        List<TEntidad> SeleccionarDetallesPorMovimiento(TMovimientoID movimientoId);
    }
}
