using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class ProjectDAL
    {
        public static int InsertProject(ProjectModel pm)
        {
            int i = 0;
            try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_InsertProject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjTitle", pm.ProjTitle);
                cmd.Parameters.AddWithValue("@ProjDetails", pm.ProjDetails);
                cmd.Parameters.AddWithValue("@FaclID", pm.FaclID);
                cmd.Parameters.AddWithValue("@ProjIsActive", pm.ProjIsActive);
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return i;
        }

        public static int UpdateProject(ProjectModel pm)
        {
            int i = 0;
            try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_UpdateProject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjID", pm.ProjID);
                cmd.Parameters.AddWithValue("@ProjTitle", pm.ProjTitle);
                cmd.Parameters.AddWithValue("@ProjDetails", pm.ProjDetails);
                cmd.Parameters.AddWithValue("@FaclID", pm.FaclID);
                cmd.Parameters.AddWithValue("@ProjIsActive", pm.ProjIsActive);
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return i;
        }

        public static List<ProjectModel> GetActiveProjectsByFaculty(int FaclID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetActiveProjectsByFaculty", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FaclID", FaclID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<ProjectModel> projectList = new List<ProjectModel>();
            while (sdr.Read())
            {
                ProjectModel proj = new ProjectModel();
                proj.ProjID = int.Parse(sdr["ProjID"].ToString());
                proj.ProjTitle = sdr["ProjTitle"].ToString();
                proj.ProjDetails = sdr["ProjDetails"].ToString();
                proj.ProjIsActive = bool.Parse(sdr["ProjIsActive"].ToString());
                projectList.Add(proj);
            }

            con.Close();
            return projectList;
        }

		public static List<ProjectModel> GetPendingProjectsByFaculty(int FaclID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetPendingProjectsByFaculty", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FaclID", FaclID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<ProjectModel> projectList = new List<ProjectModel>();
			while (sdr.Read())
			{
				ProjectModel proj = new ProjectModel();
				proj.SupID = int.Parse(sdr["SupID"].ToString());
				proj.ProjID = int.Parse(sdr["ProjID"].ToString());
				proj.ProjTitle = sdr["ProjTitle"].ToString();
				proj.FaclFirstName = sdr["FaclFirstName"].ToString();
				proj.FaclLastName = sdr["FaclLastName"].ToString();
				proj.SgID = int.Parse(sdr["SgID"].ToString());
				proj.SgName = sdr["SgName"].ToString();
				proj.ProjDetails = sdr["ProjDetails"].ToString();
				proj.SupIsActive = bool.Parse(sdr["SupIsActive"].ToString());
				proj.ProjIsPending = bool.Parse(sdr["ProjIsPending"].ToString());
				proj.ProjIsActive = bool.Parse(sdr["ProjIsActive"].ToString());
				projectList.Add(proj);
			}

			con.Close();
			return projectList;
		}

		public static List<ProjectModel> GetProjectsByFaculty(int FaclID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetActiveProjectsByFaculty", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FaclID", FaclID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<ProjectModel> projectList = new List<ProjectModel>();
			while (sdr.Read())
			{
				ProjectModel proj = new ProjectModel();
				proj.ProjID = int.Parse(sdr["ProjID"].ToString());
				proj.ProjTitle = sdr["ProjTitle"].ToString();
				proj.ProjDetails = sdr["ProjDetails"].ToString();
				proj.ProjIsActive = bool.Parse(sdr["ProjIsActive"].ToString());
				projectList.Add(proj);
			}

			con.Close();
			return projectList;
		}

		public static List<ProjectModel> ViewAvailableProjects()
		{
			List<ProjectModel> projectList = new List<ProjectModel>();
			try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_ViewAvailableProjects", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ProjectModel proj = new ProjectModel();
                    proj.ProjID = int.Parse(sdr["ProjID"].ToString());
                    proj.ProjTitle = sdr["ProjTitle"].ToString();
					proj.ProjDetails = sdr["ProjDetails"].ToString();
					proj.FaclFirstName = sdr["FaclFirstName"].ToString();
					proj.FaclLastName = sdr["FaclLastName"].ToString();
					projectList.Add(proj);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
			return projectList;
		}


    }
}
