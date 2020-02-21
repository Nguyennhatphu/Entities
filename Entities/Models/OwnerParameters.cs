using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
	public class OwnerParameters : QueryStringParameters // Thừa kế phân trang từ lớp QueryStringParameters 
	{
		public OwnerParameters()
		{
			OrderBy = "name";
		}
		// Tạo bộ lọc theo ngày tháng năm sinh
		public uint MinYearOfBirth { get; set; }
		public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;

		public bool ValidYearRange => MaxYearOfBirth > MinYearOfBirth;
		public string Name { get; set; }
	}
}
