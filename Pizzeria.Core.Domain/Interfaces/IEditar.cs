using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Domain.Interfaces
{
	public interface IEditar<TEntidad>
	{
		void Editar(TEntidad entidad);
	}
}
