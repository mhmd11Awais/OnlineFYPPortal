using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
	public class ProjectRequestModel
	{
		public int RequestID { get; set; }
		public int ProjID { get; set; }
		public int StdID { get; set; }
		public string? RequestDate { get; set; }
		public bool? IsAccepted { get; set; }

		public int FaclID { get; set; }
		public string? ProjTitle { get; set; }
		public string? ProjDetails { get; set; }
		public string? StdFirstName { get; set; }
		public string? StdLastName { get; set; }
		public string? FaclFirstName { get; set; }
		public string? FaclLastName { get; set; }

	}
}
