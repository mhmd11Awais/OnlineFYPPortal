using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class ProjectTaskDAL
	{
		public static int CreateTask(ProjectTaskModel ptm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_CreateTask", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@TaskTitle", ptm.TaskTitle);
			cmd.Parameters.AddWithValue("@TaskDetails", ptm.TaskDetails);
			cmd.Parameters.AddWithValue("@SupID", ptm.SupID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<ProjectTaskModel> ViewTasks()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_ViewTasks", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<ProjectTaskModel> ProjTasklist = new List<ProjectTaskModel>();
			while (sdr.Read())
			{
				ProjectTaskModel projtask = new ProjectTaskModel();
				projtask.TaskID = int.Parse(sdr["TaskID"].ToString());
				projtask.TaskTitle = sdr["TaskTitle"].ToString();
				projtask.TaskDetails = sdr["TaskDetails"].ToString();
				projtask.FaclFirstName = sdr["FaclFirstName"].ToString();
				projtask.FaclLastName = sdr["FaclLastName"].ToString();
				projtask.ProjTitle = sdr["ProjTitle"].ToString();
				projtask.SgName = sdr["SgName"].ToString();
				string decision = sdr["TaskIsCompleted"].ToString();
				if (decision == "")
				{
					//projtask.TaskIsCompleted = bool.Parse(sdr["TaskIsCompleted"].ToString());
				}
				else
				{
					projtask.TaskIsCompleted = bool.Parse(sdr["TaskIsCompleted"].ToString());
				}
				ProjTasklist.Add(projtask);
			}
			con.Close();
			return ProjTasklist;
		}

		public static List<ProjectTaskModel> GetTaskByID(int TaskID)
		{
			List<ProjectTaskModel> ProjTasklist = new List<ProjectTaskModel>();
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_ViewAvailableProjects", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@TaskID", TaskID);

				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					ProjectTaskModel projtask = new ProjectTaskModel();
					projtask.TaskTitle = sdr["TaskTitle"].ToString();
					projtask.TaskDetails = sdr["TaskDetails"].ToString();
					projtask.FaclFirstName = sdr["FaclFirstName"].ToString();
					projtask.FaclLastName = sdr["FaclLastName"].ToString();
					projtask.ProjTitle = sdr["ProjTitle"].ToString();
					projtask.SgName = sdr["SgName"].ToString();
					string decision = sdr["TaskIsCompleted"].ToString();
					if (decision == "")
					{
						//projtask.TaskIsCompleted = bool.Parse(sdr["TaskIsCompleted"].ToString());
					}
					else
					{
						projtask.TaskIsCompleted = bool.Parse(sdr["TaskIsCompleted"].ToString());
					}
					ProjTasklist.Add(projtask);
				}
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return ProjTasklist;
		}

		public static int EditTaskDetails(ProjectTaskModel ptm)
		{
			int i = 0;
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_EditTaskDetails", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@TaskID", ptm.TaskID);
				cmd.Parameters.AddWithValue("@TaskDetails", ptm.TaskDetails);
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return i;
		}

		public static int UpdateTaskCompletion(ProjectTaskModel ptm)
		{
			int i = 0;
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_UpdateTaskCompletion", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@TaskID", ptm.TaskID);
				cmd.Parameters.AddWithValue("@TaskIsCompleted", ptm.TaskIsCompleted);
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return i;
		}

	}
}
