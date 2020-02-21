using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Helper
{
	public interface IDataShaper<T>
	{
		IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString);
		ExpandoObject ShapeData(T entity, string fieldsString);
	}
}
