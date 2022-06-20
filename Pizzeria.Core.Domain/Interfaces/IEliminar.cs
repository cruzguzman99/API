using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Domain.Interfaces
{
	public interface IEliminar<TEntidadID>
	{
		void Eliminar(TEntidadID entidadId);
	}
}
