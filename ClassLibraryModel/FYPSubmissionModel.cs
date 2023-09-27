using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
	public class FYPSubmissionModel
	{
		public int SubmissionID { get; set; }
		public int FYPID { get; set; }
		public int SupID { get; set; }
		public string? SubmitFile { get; set; }
		public string? ProjStartDate { get; set; }
		public string? ProjEndDate { get; set; }
		public bool? FypSubmitted { get; set; }

		public string? FYPTitle { get; set; }
		public string? ProjTitle { get; set; }
		public string? SgName { get; set; }
	}
}
