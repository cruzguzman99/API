using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Domain.Interfaces
{
	public interface IAgregar<TEntidad>
	{
		TEntidad Agregar(TEntidad entidad);
	}
}
