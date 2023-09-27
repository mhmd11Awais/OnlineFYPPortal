using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ProjectModel
    {
        public int ProjID { get; set; }
        public string? ProjTitle { get; set; }
        public string? ProjDetails { get; set; }
        public int FaclID { get; set; }
		public bool? ProjIsActive { get; set; }
		public bool? ProjIsPending { get; set; }


		public int SgID { get; set; }
		public string? SgName { get; set; }
		public int SupID { get; set; }
		public bool? SupIsActive { get; set; }
		public string? FaclFirstName { get; set; }
        public string? FaclLastName { get; set; }
    }
}
