using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class AnnouncementDAL
    {
        public static int InsertAnnouncement(AnnouncementModel annm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_InsertAnnouncement", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnnouncementText", annm.AnnouncementText);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<AnnouncementModel> GetAnnouncements()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetAnnouncements", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<AnnouncementModel> Announcementlist = new List<AnnouncementModel>();
            while (sdr.Read())
            {
                AnnouncementModel announcement = new AnnouncementModel();
                announcement.AnnouncementID = int.Parse(sdr["AnnouncementID"].ToString());
                announcement.AnnouncementText = sdr["AnnouncementText"].ToString();
                announcement.AnnouncementDate = sdr["AnnouncementDate"].ToString();
                announcement.UpdatedDate = sdr["UpdatedDate"].ToString();
                Announcementlist.Add(announcement);
            }
            con.Close();
            return Announcementlist;
        }

        public static List<AnnouncementModel> GetAnnouncementByID(int AnnouncementID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetAnnouncementByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnnouncementID", AnnouncementID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<AnnouncementModel> Announcementlist = new List<AnnouncementModel>();
            while (sdr.Read())
            {
                AnnouncementModel announcement = new AnnouncementModel();
                announcement.AnnouncementText = sdr["AnnouncementText"].ToString();
                announcement.AnnouncementDate = sdr["AnnouncementDate"].ToString();
                /*if (sdr["UpdatedDate"] != DBNull.Value)
                {
                    announcement.UpdatedDate = sdr["UpdatedDate"].ToString();
                }*/
                string decision = sdr["UpdatedDate"].ToString();
                if (decision != "")
                {
                    announcement.UpdatedDate = sdr["UpdatedDate"].ToString();
                }
                Announcementlist.Add(announcement);
            }
            con.Close();
            return Announcementlist;
        }

        public static int UpdateAnnouncement(AnnouncementModel annm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_UpdateAnnouncement", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnnouncementID", annm.AnnouncementID);
            cmd.Parameters.AddWithValue("@AnnouncementText", annm.AnnouncementText);
            cmd.Parameters.AddWithValue("@AnnouncementDate", annm.AnnouncementDate);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

		public static int DeleteAnnouncement(int AnnouncementID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteAnnouncement", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@AnnouncementID", AnnouncementID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

	}
}
