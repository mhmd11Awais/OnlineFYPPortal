using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class SGMemberDAL
    {
		public static int JoinSGroup(SGMemberModel sgm)
		{
			int i = 0;
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_JoinSGroup", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@StdID", sgm.StdID);
				cmd.Parameters.AddWithValue("@SgID", sgm.SgID);
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return i;
		}

		public static List<SGMemberModel> GetSGMemberByStd(int StdID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetSGMemberByStd", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@StdID", StdID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<SGMemberModel> sgMemberList = new List<SGMemberModel>();
			while (sdr.Read())
			{
				SGMemberModel sgMember = new SGMemberModel();
				sgMember.SgmID = int.Parse(sdr["SgmID"].ToString());
				sgMember.StdFirstName = sdr["StdFirstName"].ToString();
				sgMember.StdLastName = sdr["StdLastName"].ToString();
				sgMember.SgName = sdr["SgName"].ToString();
				sgMember.SgmIsLeader = bool.Parse(sdr["SgmIsLeader"].ToString());
				sgMember.SgmIsActive = bool.Parse(sdr["SgmIsActive"].ToString());
				sgMemberList.Add(sgMember);
			}

			con.Close();
			return sgMemberList;
		}

		public static List<SGMemberModel> GetSGMemberByID(int SgmID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetSGMemberByID", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SgmID", SgmID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<SGMemberModel> sgMemberList = new List<SGMemberModel>();
			while (sdr.Read())
			{
				SGMemberModel sgMember = new SGMemberModel();
				sgMember.StdID = int.Parse(sdr["StdID"].ToString());
				sgMember.SgID = int.Parse(sdr["SgID"].ToString());
				sgMember.SgmIsLeader = bool.Parse(sdr["SgmIsLeader"].ToString());
				sgMember.SgmIsActive = bool.Parse(sdr["SgmIsActive"].ToString());
				sgMemberList.Add(sgMember);
			}

			con.Close();
			return sgMemberList;
		}

		public static int EditSGMember(SGMemberModel sgm)
		{
			int i = 0;
			try
			{
				SqlConnection con = DBHelper.GetConnection();
				con.Open();
				SqlCommand cmd = new SqlCommand("Sp_EditSGMember", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@SgmID", sgm.SgmID);
				cmd.Parameters.AddWithValue("@StdID", sgm.StdID);
				cmd.Parameters.AddWithValue("@SgID", sgm.SgID);
				cmd.Parameters.AddWithValue("@SgmIsLeader", sgm.SgmIsLeader);
				cmd.Parameters.AddWithValue("@SgmIsActive", sgm.SgmIsActive);
				i = cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return i;
		}

		public static int DeleteSGMember(int SgmID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteSGMember", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SgmID", SgmID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}
