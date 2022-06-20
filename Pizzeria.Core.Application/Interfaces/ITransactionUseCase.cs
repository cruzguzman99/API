using System;
using System.Collections.Generic;
using System.Text;
using Pizzeria.Core.Domain.Interfaces;

namespace Pizzeria.Core.Application.Interfaces
{
	public interface ITransactionUseCase<TEntidad, TEntidadID> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>
	{
		void Anular(TEntidadID entidadId);
	}
}
