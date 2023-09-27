using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class SGMemberModel
	{
		public int SgmID { get; set; }
		public int StdID { get; set; }
		public int SgID { get; set; }
		public bool? SgmIsLeader { get; set; }
		public bool? SgmIsActive { get; set; }

		public string? StdFirstName { get; set; }
		public string? StdLastName { get; set; }
		public string? SgName { get; set; }
	}
}
