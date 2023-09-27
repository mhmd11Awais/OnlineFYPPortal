using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class ProjectRequestDAL
	{
		public static int RequestProject(ProjectRequestModel prm)
		{
			int i = 0;
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_RequestProject", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ProjID", prm.ProjID);
				cmd.Parameters.AddWithValue("@StdID", prm.StdID);
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return i;
		}

		public static int RespondToProjectRequest(ProjectRequestModel prm)
		{
			int i = 0;
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_RespondToProjectRequest", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@RequestID", prm.RequestID);
				cmd.Parameters.AddWithValue("@IsAccepted", prm.IsAccepted);
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return i;
		}

		public static List<ProjectRequestModel> GetProjectRequestsByStudent(int StdID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetProjectRequestsByStudent", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@StdID", StdID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<ProjectRequestModel> projectRequestList = new List<ProjectRequestModel>();
			while (sdr.Read())
			{
				ProjectRequestModel projRequest = new ProjectRequestModel();
				projRequest.RequestID = int.Parse(sdr["RequestID"].ToString());
				projRequest.ProjTitle = sdr["ProjTitle"].ToString();
				projRequest.ProjDetails = sdr["ProjDetails"].ToString();
				projRequest.FaclFirstName = sdr["FaclFirstName"].ToString();
				projRequest.FaclLastName = sdr["FaclLastName"].ToString();
				projRequest.RequestDate = sdr["RequestDate"].ToString();
				string decision = sdr["IsAccepted"].ToString();
				if (decision == "")
				{
					//projRequest.IsAccepted = bool.Parse(sdr["IsAccepted"].ToString());
				}
				else
				{
					projRequest.IsAccepted = bool.Parse(sdr["IsAccepted"].ToString());
				}
				projectRequestList.Add(projRequest);
			}

			con.Close();
			return projectRequestList;
		}

		public static List<ProjectRequestModel> GetProjectRequestsByProject(int ProjID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetProjectRequestsByProject", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ProjID", ProjID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<ProjectRequestModel> projectRequestList = new List<ProjectRequestModel>();
			while (sdr.Read())
			{
				ProjectRequestModel projRequest = new ProjectRequestModel();
				projRequest.RequestID = int.Parse(sdr["RequestID"].ToString());
				projRequest.ProjTitle = sdr["ProjTitle"].ToString();
				projRequest.ProjDetails = sdr["ProjDetails"].ToString();
				projRequest.StdFirstName = sdr["StdFirstName"].ToString();
				projRequest.StdLastName = sdr["StdLastName"].ToString();
				projRequest.RequestDate = sdr["RequestDate"].ToString();
				string decision = sdr["IsAccepted"].ToString();
				if (decision == "")
				{
					//projRequest.IsAccepted = bool.Parse(sdr["IsAccepted"].ToString());
				}
				else
				{
					projRequest.IsAccepted = bool.Parse(sdr["IsAccepted"].ToString());
				}
				projectRequestList.Add(projRequest);
			}

			con.Close();
			return projectRequestList;
		}

	}
}
