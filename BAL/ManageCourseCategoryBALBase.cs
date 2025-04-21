using WebApplication7.Areas.Admin.Models;
using WebApplication7.Areas.User.Models;
using WebApplication7.DAL;

namespace WebApplication7.BAL
{
	public class ManageCourseCategoryBALBase
	{

		#region PR_COURSECATEGORY_SELECTALL
		public List<AdminModel> PR_COURSECATEGORY_SELECTALL()
		{
			try
			{
				ManageCourseCategoryDALBase manageCourseCategoryDALBase = new ManageCourseCategoryDALBase();
				List<AdminModel> adminModels = manageCourseCategoryDALBase.PR_COURSECATEGORY_SELECTALL();
				return adminModels;
			}
			catch (Exception e)
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
				ManageCourseCategoryDALBase manageCourseCategoryDALBase = new ManageCourseCategoryDALBase();
				AdminModel adminModel = manageCourseCategoryDALBase.PR_COURSECATEGORY_SELECTBYPK(CourseCategoryID);
				return adminModel;
			}
			catch (Exception e)
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
				ManageCourseCategoryDALBase manageCourseCategoryDALBase = new ManageCourseCategoryDALBase();
				if (manageCourseCategoryDALBase.PR_COURSECATEGORY_INSERT(model))
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
				ManageCourseCategoryDALBase manageCourseCategoryDALBase = new ManageCourseCategoryDALBase();
				if (manageCourseCategoryDALBase.PR_COURSECATEGORY_UPDATE(model))
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
				ManageCourseCategoryDALBase manageCourseCategoryDALBase = new ManageCourseCategoryDALBase();
				if (manageCourseCategoryDALBase.PR_COURSECATEGORY_DELETE(CourseCategoryID))
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

		#region PR_COURSECATEGORY_SEARCH
		public List<AdminModel> PR_COURSECATEGORY_SEARCH(AdminModel model)
		{
			try
			{
				ManageCourseCategoryDALBase manageCourseCategoryDALBase = new ManageCourseCategoryDALBase();
				List<AdminModel> adminModel = manageCourseCategoryDALBase.PR_COURSECATEGORY_SEARCH(model);
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
