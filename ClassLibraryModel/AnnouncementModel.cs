using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class AnnouncementModel
    {
        public int AnnouncementID { get; set; }
        public string? AnnouncementText { get; set; }
        public string? AnnouncementDate { get; set; }
        public string? UpdatedDate { get; set; }
    }
}
