using WebApplication7.Areas.Admin.Models;
using WebApplication7.DAL;

namespace WebApplication7.BAL
{
	public class ManageCourseBALBase
	{

		#region PR_COURSE_SELECTALL
		public List<AdminModel> PR_COURSE_SELECTALL()
		{
			try
			{
				ManageCourseDALBase manageCourseDALBase = new ManageCourseDALBase();		
				List<AdminModel> adminModels = manageCourseDALBase.PR_COURSE_SELECTALL();
				return adminModels;
			}
			catch (Exception e)
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
				ManageCourseDALBase manageCourseDALBase = new ManageCourseDALBase();
				AdminModel adminModel = manageCourseDALBase.PR_COURSE_SELECTBYPK(CourseID);
				return adminModel;
			}
			catch (Exception e)
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
				ManageCourseDALBase manageCourseDALBase = new ManageCourseDALBase();
				if (manageCourseDALBase.PR_COURSE_INSERT(model))
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
				ManageCourseDALBase manageCourseDALBase = new ManageCourseDALBase();
				if (manageCourseDALBase.PR_COURSE_UPDATE(model))
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
				ManageCourseDALBase manageCourseDALBase = new ManageCourseDALBase();
				if (manageCourseDALBase.PR_COURSE_DELETE(CourseID))
					return true;
				else
					return false;
			}
			catch (Exception e)
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
				ManageCourseDALBase manageCourseDALBase = new ManageCourseDALBase();
				List<AdminModel> adminModel = manageCourseDALBase.PR_COURSE_SEARCH(model);
				return adminModel;
			}
			catch (Exception e)
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
				ManageCourseDALBase manageCourseDALBase = new ManageCourseDALBase();
				List<AdminModel> adminModels = manageCourseDALBase.PR_COURSECATEGORY_DROPDOWN();
				return adminModels;
			}
			catch (Exception e)
			{
				return null;
			}
		}
		#endregion

	}
}
