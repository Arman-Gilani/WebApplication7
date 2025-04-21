using WebApplication7.Areas.Admin.Models;
using WebApplication7.DAL;

namespace WebApplication7.BAL
{
	public class ManageCourseContentBALBase
	{

		#region PR_COURSE_SELECTALL
		public List<AdminModel> PR_COURSE_SELECTALL()
		{
			try
			{
				ManageCourseContentDALBase manageCourseContentDALBase = new ManageCourseContentDALBase();		
				List<AdminModel> adminModels = manageCourseContentDALBase.PR_COURSE_SELECTALL();
				return adminModels;
			}
			catch (Exception e)
			{
				return null;
			}
		}
		#endregion

		#region PR_COURSE_SEARCH
		public List<AdminModel> PR_COURSE_SEARCH(AdminModel model)
		{
			try
			{
				ManageCourseContentDALBase manageCourseContentDALBase = new ManageCourseContentDALBase();
				List<AdminModel> adminModel = manageCourseContentDALBase.PR_COURSE_SEARCH(model);
				return adminModel;
			}
			catch (Exception e)
			{
				return null;
			}
		}
		#endregion

	}
}
