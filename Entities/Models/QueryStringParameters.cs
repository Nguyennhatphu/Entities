using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
	//Class cha
	public abstract class QueryStringParameters
	{


		const int maxPageSize = 50;
		public int PageNumber { get; set; } = 1;

		private int _pageSize = 10;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
		public string OrderBy { get; set; }// Sắp xếp dữ liệu trùng
		public string Fields { get; set; }// thuộc tính fields làm tham số chuỗi truy vấn
	}
}
