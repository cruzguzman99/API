using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Domain.Interfaces;

namespace Pizzeria.Core.Application.Interfaces
{
	public interface INameUseCase<TEntidad, TEntidadID, TEntidadNombre>
		 : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ISeleccionarPorNombre<TEntidad, TEntidadNombre>, ITransaccion
	{ }
}
