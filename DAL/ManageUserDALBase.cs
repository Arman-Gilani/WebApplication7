using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using WebApplication7.Areas.Admin.Models;

namespace WebApplication7.DAL
{
	public class ManageUserDALBase : DAL_Helper
	{

		#region PR_USER_SELECTALLUSER
		public List<AdminModel> PR_USER_SELECTALLUSER()
		{
			try
			{
				List<AdminModel> adminModels = new List<AdminModel>();
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_SELECTALLUSER");
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						AdminModel model = new AdminModel();
						model.UserID = (int)dr["UserID"];
						model.UserName = dr["UserName"].ToString();
						model.UserEmail = dr["UserEmail"].ToString();
						model.UserPassword = dr["UserPassword"].ToString();
						model.UserContact = dr["UserContact"].ToString();
						model.UserProfileImageURL = dr["UserProfileImageURL"].ToString();
						model.IsActive = (bool)dr["IsActive"];
						model.IsAdmin = (bool)dr["IsAdmin"];
						model.Created = dr["Created"].ToString();
						model.Modified = dr["Modified"].ToString();
						adminModels.Add(model);	
					}
				}
				return adminModels;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		#region PR_USER_SELECTBYPK
		public AdminModel PR_USER_SELECTBYPK(int UserID)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_SELECTBYPK");
				sqlDatabase.AddInParameter(dbCommand,"UserID",SqlDbType.Int,UserID);
				AdminModel model = new AdminModel();	
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						model.UserID = (int)dr["UserID"];
						model.UserName = dr["UserName"].ToString();
						model.UserEmail = dr["UserEmail"].ToString();
						model.UserPassword = dr["UserPassword"].ToString();
						model.UserContact = dr["UserContact"].ToString();
						model.UserProfileImageURL = dr["UserProfileImageURL"].ToString();
						model.IsActive = (bool)dr["IsActive"];
						model.IsAdmin = (bool)dr["IsAdmin"];	
						model.Created = dr["Created"].ToString();
						model.Modified = dr["Modified"].ToString();
					}
				}
				return model;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		#region PR_USER_INSERT
		public bool PR_USER_INSERT(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_INSERT");
				sqlDatabase.AddInParameter(dbCommand, "UserName", SqlDbType.VarChar, model.UserName);
				sqlDatabase.AddInParameter(dbCommand, "UserEmail", SqlDbType.VarChar, model.UserEmail);
				sqlDatabase.AddInParameter(dbCommand, "UserPassword", SqlDbType.NVarChar, model.UserPassword);
				sqlDatabase.AddInParameter(dbCommand, "UserContact", SqlDbType.NVarChar, model.UserContact ?? "");
				sqlDatabase.AddInParameter(dbCommand, "UserProfileImageURL", SqlDbType.VarChar, model.UserProfileImageURL);
				sqlDatabase.AddInParameter(dbCommand, "IsActive", SqlDbType.Bit, model.IsActive);
				sqlDatabase.AddInParameter(dbCommand, "IsAdmin", SqlDbType.Bit, model.IsAdmin);
				sqlDatabase.AddInParameter(dbCommand, "Created", SqlDbType.DateTime, DateTime.Now);
				sqlDatabase.AddInParameter(dbCommand, "Modified", SqlDbType.DateTime, DateTime.Now);
				if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
					return true;
				else
					return false;
			}
			catch
			{
				return false;
			}
		}
		#endregion

		#region PR_USER_SEARCH
		public List<AdminModel> PR_USER_SEARCH(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_SEARCH");
				sqlDatabase.AddInParameter(dbCommand, "UserID", SqlDbType.Int, model.UserID);
				sqlDatabase.AddInParameter(dbCommand, "UserName", SqlDbType.VarChar, model.UserName);
				List<AdminModel> models = new List<AdminModel>();
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						AdminModel model1 = new AdminModel();
						model1.UserID = (int)dr["UserID"];
						model1.UserName = dr["UserName"].ToString();
						model1.UserEmail = dr["UserEmail"].ToString();
						model1.UserPassword = dr["UserPassword"].ToString();
						model1.UserContact = dr["UserContact"].ToString();
						model1.UserProfileImageURL = dr["UserProfileImageURL"].ToString();
						model1.IsActive = (bool)dr["IsActive"];
						model1.IsAdmin = (bool)dr["IsAdmin"];
						model1.Created = dr["Created"].ToString();
						model1.Modified = dr["Modified"].ToString();
						models.Add(model1);
					}
				}
				return models;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

	}
}
