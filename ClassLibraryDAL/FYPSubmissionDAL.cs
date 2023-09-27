using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
	public class FYPSubmissionDAL
	{
		public static int InsertFypSubmission(FYPSubmissionModel fypsm)
		{
			int i = 0;
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_InsertFypSubmission", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@FYPID", fypsm.FYPID);
				cmd.Parameters.AddWithValue("@SupID", fypsm.SupID);
				cmd.Parameters.AddWithValue("@ProjStartDate", fypsm.ProjStartDate);
				cmd.Parameters.AddWithValue("@ProjEndDate", fypsm.ProjEndDate);
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return i;
		}

		public static List<FYPSubmissionModel> GetFypSubmissionByID(int SubmissionID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetFypSubmissionByID", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SubmissionID", SubmissionID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<FYPSubmissionModel> fypSubmissionList = new List<FYPSubmissionModel>();
			while (sdr.Read())
			{
				FYPSubmissionModel fypsubmission = new FYPSubmissionModel();
				fypsubmission.SubmissionID = int.Parse(sdr["SubmissionID"].ToString());
				fypsubmission.FYPID = int.Parse(sdr["FYPID"].ToString());
				fypsubmission.SupID = int.Parse(sdr["SupID"].ToString());
				fypsubmission.SubmitFile = sdr["SubmitFile"].ToString();
				fypsubmission.ProjStartDate = sdr["ProjStartDate"].ToString();
				fypsubmission.ProjEndDate = sdr["ProjEndDate"].ToString();
				fypsubmission.FypSubmitted = bool.Parse(sdr["FypSubmitted"].ToString());
				fypSubmissionList.Add(fypsubmission);
			}

			con.Close();
			return fypSubmissionList;
		}

		public static int EditFypSubmission(FYPSubmissionModel fypsm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_EditFypSubmission", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SubmissionID", fypsm.SubmissionID);
			cmd.Parameters.AddWithValue("@ProjEndDate", fypsm.ProjEndDate);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<FYPSubmissionModel> GetFypSubmissions()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetFypSubmissions", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<FYPSubmissionModel> fypSubmissionList = new List<FYPSubmissionModel>();
			while (sdr.Read())
			{
				FYPSubmissionModel fypsubmission = new FYPSubmissionModel();
				fypsubmission.SubmissionID = int.Parse(sdr["SubmissionID"].ToString());
				fypsubmission.FYPTitle = sdr["FYPTitle"].ToString();
				fypsubmission.ProjTitle = sdr["ProjTitle"].ToString();
				fypsubmission.SgName = sdr["SgName"].ToString();
				fypsubmission.SubmitFile = sdr["SubmitFile"].ToString();
				fypsubmission.ProjStartDate = sdr["ProjStartDate"].ToString();
				fypsubmission.ProjEndDate = sdr["ProjEndDate"].ToString();
				fypsubmission.FypSubmitted = bool.Parse(sdr["FypSubmitted"].ToString());
				fypSubmissionList.Add(fypsubmission);
			}

			con.Close();
			return fypSubmissionList;
		}

	}
}
