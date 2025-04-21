using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using WebApplication7.Areas.Admin.Models;
using WebApplication7.Areas.User.Models;

namespace WebApplication7.DAL
{
	public class ManageCourseCategoryDALBase : DAL_Helper
	{

		#region PR_COURSECATEGORY_SELECTALL
		public List<AdminModel> PR_COURSECATEGORY_SELECTALL()
		{
			try
			{
				List<AdminModel> adminModels = new List<AdminModel>();
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSECATEGORY_SELECTALL");
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						AdminModel model = new AdminModel();
						model.CourseCategoryID = (int)dr["CourseCategoryID"];
						model.CourseCategory = dr["CourseCategory"].ToString();
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

		#region PR_COURSECATEGORY_SELECTBYPK
		public AdminModel PR_COURSECATEGORY_SELECTBYPK(int CourseCategoryID)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSECATEGORY_SELECTBYPK");
				sqlDatabase.AddInParameter(dbCommand, "CourseCategoryID", SqlDbType.Int, CourseCategoryID);
				AdminModel model = new AdminModel();
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						model.CourseCategoryID = (int)dr["CourseCategoryID"];
						model.CourseCategory = dr["CourseCategory"].ToString();
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

		#region PR_COURSECATEGORY_INSERT
		public bool PR_COURSECATEGORY_INSERT(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSECATEGORY_INSERT");
				sqlDatabase.AddInParameter(dbCommand, "CourseCategory", SqlDbType.VarChar, model.CourseCategory);
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

		#region PR_COURSECATEGORY_UPDATE
		public bool PR_COURSECATEGORY_UPDATE(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSECATEGORY_UPDATE");
				sqlDatabase.AddInParameter(dbCommand, "CourseCategoryID", SqlDbType.Int, model.CourseCategoryID);
				sqlDatabase.AddInParameter(dbCommand, "CourseCategory", SqlDbType.VarChar, model.CourseCategory);
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

		#region PR_COURSECATEGORY_DELETE
		public bool PR_COURSECATEGORY_DELETE(int CourseCategoryID)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSECATEGORY_DELETE");
				sqlDatabase.AddInParameter(dbCommand, "CourseCategoryID", SqlDbType.Int, CourseCategoryID);
				if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		#endregion

		#region PR_COURSECATEGORY_SEARCH
		public List<AdminModel> PR_COURSECATEGORY_SEARCH(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSECATEGORY_SEARCH");
				sqlDatabase.AddInParameter(dbCommand, "CourseCategoryID", SqlDbType.Int, model.CourseCategoryID);
				sqlDatabase.AddInParameter(dbCommand, "CourseCategory", SqlDbType.VarChar, model.CourseCategory);
				List<AdminModel> models = new List<AdminModel> ();
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						AdminModel model1 = new AdminModel();
						model1.CourseCategoryID = (int)dr["CourseCategoryID"];
						model1.CourseCategory = dr["CourseCategory"].ToString();
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
