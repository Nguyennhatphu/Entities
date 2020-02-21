using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Helper
{
	public interface ISortHelper<T>
	{
		IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
	}
}
