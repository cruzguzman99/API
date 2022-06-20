using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Domain.Interfaces;

namespace Pizzeria.Core.Application.Interfaces
{
	public interface IBaseUseCase<TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
	{ }
}
