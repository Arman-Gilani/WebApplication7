using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using WebApplication7.Areas.Admin.Models;

namespace WebApplication7.DAL
{
	public class DashboardCountsDALBase : DAL_Helper
	{

		#region PR_ADMIN_DASHBOARD_COUNTS
		public AdminModel PR_ADMIN_DASHBOARD_COUNTS()
		{
			try
			{
				AdminModel model = new AdminModel();
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ADMIN_DASHBOARD_COUNTS");
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						model.AdminsCount = (int)dr["AdminsCount"];
						model.UsersCount = (int)dr["UsersCount"];
						model.CourseCategoryCount = (int)dr["CourseCategoryCount"];
						model.CoursesCount = (int)dr["CoursesCount"];
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

		#region PR_USER_DASHBOARD_COUNTS
		public AdminModel PR_USER_DASHBOARD_COUNTS()
		{
			try
			{
				AdminModel model = new AdminModel();
				SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_DASHBOARD_COUNTS");
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						model.CourseCategoryCount = (int)dr["CourseCategoryCount"];
						model.CoursesCount = (int)dr["CoursesCount"];
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

	}
}
