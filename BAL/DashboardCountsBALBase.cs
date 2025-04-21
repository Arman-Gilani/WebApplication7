using WebApplication7.Areas.Admin.Models;
using WebApplication7.DAL;

namespace WebApplication7.BAL
{
	public class DashboardCountsBALBase
	{

		#region PR_ADMIN_DASHBOARD_COUNTS
		public AdminModel PR_ADMIN_DASHBOARD_COUNTS()
		{
			try
			{
				DashboardCountsDALBase dashboardCountsDALBase = new DashboardCountsDALBase();		
				AdminModel model = dashboardCountsDALBase.PR_ADMIN_DASHBOARD_COUNTS();
				return model;
			}
			catch (Exception e)
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
				DashboardCountsDALBase dashboardCountsDALBase = new DashboardCountsDALBase();
				AdminModel model = dashboardCountsDALBase.PR_USER_DASHBOARD_COUNTS();
				return model;
			}
			catch (Exception e)
			{
				return null;
			}
		}
		#endregion

	}
}
