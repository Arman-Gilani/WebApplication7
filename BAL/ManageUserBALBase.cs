using WebApplication7.Areas.Admin.Models;
using WebApplication7.DAL;

namespace WebApplication7.BAL
{
	public class ManageUserBALBase
	{

		#region PR_USER_SELECTALLUSER
		public List<AdminModel> PR_USER_SELECTALLUSER()
		{
			try
			{
				ManageUserDALBase manageUserDALBase = new ManageUserDALBase();
				List<AdminModel> adminModels = manageUserDALBase.PR_USER_SELECTALLUSER();
				return adminModels;
			}
			catch (Exception e)
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
				ManageUserDALBase manageUserDALBase = new ManageUserDALBase();
				AdminModel adminModel = manageUserDALBase.PR_USER_SELECTBYPK(UserID);
				return adminModel;
			}
			catch (Exception e)
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
				ManageUserDALBase manageUserDALBase = new ManageUserDALBase();
				if (manageUserDALBase.PR_USER_INSERT(model))
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
				ManageUserDALBase manageUserDALBase = new ManageUserDALBase();
				List<AdminModel> adminModel = manageUserDALBase.PR_USER_SEARCH(model);
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
