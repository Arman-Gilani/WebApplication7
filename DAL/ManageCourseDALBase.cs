using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using WebApplication7.Areas.Admin.Models;

namespace WebApplication7.DAL
{
	public class ManageCourseDALBase : DAL_Helper
	{

		#region PR_COURSE_SELECTALL
		public List<AdminModel> PR_COURSE_SELECTALL()
		{
			try
			{
				List<AdminModel> adminModels = new List<AdminModel>();
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSE_SELECTALL");
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{		
					while (dr.Read())
					{
						AdminModel model = new AdminModel();
						model.CourseID = (int)dr["CourseID"];
						model.CourseCategoryID = (int)dr["CourseCategoryID"];
						model.CourseCategory = dr["CourseCategory"].ToString();
						model.CourseName = dr["CourseName"].ToString();
						model.CourseLogo = dr["CourseLogo"].ToString();
						model.CourseTitle = dr["CourseTitle"].ToString();
						model.CourseDescription = dr["CourseDescription"].ToString();
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

		#region PR_COURSE_SELECTBYPK
		public AdminModel PR_COURSE_SELECTBYPK(int CourseID)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSE_SELECTBYPK");
				sqlDatabase.AddInParameter(dbCommand, "CourseID", SqlDbType.Int, CourseID);
				AdminModel model = new AdminModel();
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						model.CourseID = (int)dr["CourseID"];
						model.CourseCategoryID = (int)dr["CourseCategoryID"];
						model.CourseCategory = dr["CourseCategory"].ToString();
						model.CourseName = dr["CourseName"].ToString();
						model.CourseLogo = dr["CourseLogo"].ToString();
						model.CourseTitle = dr["CourseTitle"].ToString();
						model.CourseDescription = dr["CourseDescription"].ToString();
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

		#region PR_COURSE_INSERT
		public bool PR_COURSE_INSERT(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSE_INSERT");
				sqlDatabase.AddInParameter(dbCommand, "CourseCategoryID", SqlDbType.Int, model.CourseCategoryID);
				sqlDatabase.AddInParameter(dbCommand, "CourseName", SqlDbType.VarChar, model.CourseName);
				sqlDatabase.AddInParameter(dbCommand, "CourseLogo", SqlDbType.VarChar, model.CourseLogo);
				sqlDatabase.AddInParameter(dbCommand, "CourseTitle", SqlDbType.VarChar, model.CourseTitle);
				sqlDatabase.AddInParameter(dbCommand, "CourseDescription", SqlDbType.VarChar, model.CourseDescription);
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
		
		#region PR_COURSE_UPDATE
		public bool PR_COURSE_UPDATE(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSE_UPDATE");
				sqlDatabase.AddInParameter(dbCommand, "CourseID", SqlDbType.Int, model.CourseID);
				sqlDatabase.AddInParameter(dbCommand, "CourseCategoryID", SqlDbType.Int, model.CourseCategoryID);
				sqlDatabase.AddInParameter(dbCommand, "CourseName", SqlDbType.VarChar, model.CourseName);
				sqlDatabase.AddInParameter(dbCommand, "CourseLogo", SqlDbType.VarChar, model.CourseLogo);
				sqlDatabase.AddInParameter(dbCommand, "CourseTitle", SqlDbType.VarChar, model.CourseTitle);
				sqlDatabase.AddInParameter(dbCommand, "CourseDescription", SqlDbType.VarChar, model.CourseDescription);
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

		#region PR_COURSE_DELETE
		public bool PR_COURSE_DELETE(int CourseID)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSE_DELETE");
				sqlDatabase.AddInParameter(dbCommand, "CourseID", SqlDbType.Int, CourseID);
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

		#region PR_COURSE_SEARCH
		public List<AdminModel> PR_COURSE_SEARCH(AdminModel model)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSE_SEARCH");
				sqlDatabase.AddInParameter(dbCommand, "CourseID", SqlDbType.Int, model.CourseID);
				sqlDatabase.AddInParameter(dbCommand, "CourseName", SqlDbType.VarChar, model.CourseName);
				List<AdminModel> models = new List<AdminModel>();
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						AdminModel model1 = new AdminModel();
						model1.CourseID = (int)dr["CourseID"];
						model1.CourseCategoryID = (int)dr["CourseCategoryID"];
						model1.CourseCategory = dr["CourseCategory"].ToString();
						model1.CourseName = dr["CourseName"].ToString();
						model1.CourseLogo = dr["CourseLogo"].ToString();
						model1.CourseTitle = dr["CourseTitle"].ToString();
						model1.CourseDescription = dr["CourseDescription"].ToString();
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

		#region PR_COURSECATEGORY_DROPDOWN
		public List<AdminModel> PR_COURSECATEGORY_DROPDOWN()
		{
			try
			{
				List<AdminModel> adminModels = new List<AdminModel>();
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_COURSECATEGORY_DROPDOWN");
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						AdminModel model = new AdminModel();
						model.CourseCategoryID = (int)dr["CourseCategoryID"];
						model.CourseCategory = dr["CourseCategory"].ToString();
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

	}
}
