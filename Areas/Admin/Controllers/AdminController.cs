using Microsoft.AspNetCore.Mvc;
using WebApplication7.Areas.Admin.Models;
using WebApplication7.BAL;

namespace WebApplication7.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Admin/{Action}")]
    public class AdminController : Controller
    {

		ManageUserBALBase manageUserBALBase = new ManageUserBALBase();
        ManageCourseCategoryBALBase manageCourseCategoryBALBase = new ManageCourseCategoryBALBase();
		ManageCourseBALBase manageCourseBALBase = new ManageCourseBALBase();
		ManageCourseContentBALBase manageCourseContentBALBase = new ManageCourseContentBALBase();	
		DashboardCountsBALBase dashboardCountsBALBase = new DashboardCountsBALBase();		

		#region AdminDashboard
		public IActionResult AdminDashboard()
        {
			AdminModel model = dashboardCountsBALBase.PR_ADMIN_DASHBOARD_COUNTS();
			ViewBag.AdminsCount = model.AdminsCount;

			ViewBag.UsersCount = model.UsersCount;
			ViewBag.CourseCategoryCount = model.CourseCategoryCount;
			ViewBag.CoursesCount = model.CoursesCount;
			return View();
        }
        #endregion

        #region AdminProfile
        public IActionResult AdminProfile()
        {
            return View();
        }
        #endregion



        #region ManageCourseCategory
        public IActionResult ManageCourseCategory()
        {
			List<AdminModel> adminModels = manageCourseCategoryBALBase.PR_COURSECATEGORY_SELECTALL();
			return View(adminModels);
		}
		#endregion

		#region AddNewCourseCategory
		public IActionResult AddNewCourseCategory()
		{
			return View();
		}
		public IActionResult AddNewCourseCategory1(AdminModel model)
		{
			bool IsSuccess = manageCourseCategoryBALBase.PR_COURSECATEGORY_INSERT(model);
			return RedirectToAction("ManageCourseCategory");
		}
		#endregion

		#region AdminCourseCategoryEdit
		public IActionResult AdminCourseCategoryEdit(int CourseCategoryID)
		{
			AdminModel model = manageCourseCategoryBALBase.PR_COURSECATEGORY_SELECTBYPK(CourseCategoryID);
			ViewBag.CourseCategoryID = model.CourseCategoryID;
			ViewBag.CourseCategory = model.CourseCategory;
			ViewBag.Created = model.Created;
			ViewBag.Modified = model.Modified;
			return View();
		}
		public IActionResult AdminCourseCategoryEdit1(AdminModel model)
		{
			bool IsSuccess = manageCourseCategoryBALBase.PR_COURSECATEGORY_UPDATE(model);
			return RedirectToAction("ManageCourseCategory");
		}
		#endregion

		#region CourseCategoryDelete
		public IActionResult CourseCategoryDelete(int CourseCategoryID)
		{
			bool IsSuccess = manageCourseCategoryBALBase.PR_COURSECATEGORY_DELETE(CourseCategoryID);
			return RedirectToAction("ManageCourseCategory");
		}
		#endregion

		#region SearchCourseCategory
		public IActionResult SearchCourseCategory(AdminModel model)
        {
			List<AdminModel> model1 = manageCourseCategoryBALBase.PR_COURSECATEGORY_SEARCH(model);
			return View("ManageCourseCategory",model1);
        }
		#endregion



		#region ManageCourse
		public IActionResult ManageCourse()
        {
			List<AdminModel> adminModels = manageCourseBALBase.PR_COURSE_SELECTALL();
			return View(adminModels);
		}
		#endregion

		#region AddNewCourse
		public IActionResult AddNewCourse()
		{
			CourseCategoryDropDown();	
			return View();
		}
		public IActionResult AddNewCourse1(AdminModel model)
		{
			bool IsSuccess = manageCourseBALBase.PR_COURSE_INSERT(model);
			return RedirectToAction("ManageCourse");
		}
		#endregion

		#region EditCourse
		public IActionResult EditCourse(int CourseID)
		{
			AdminModel model = manageCourseBALBase.PR_COURSE_SELECTBYPK(CourseID);
			ViewBag.CourseID = model.CourseID;
			ViewBag.CourseCategoryID = model.CourseCategoryID;
			ViewBag.CourseName = model.CourseName;
			ViewBag.CourseLogo = model.CourseLogo;
			ViewBag.CourseTitle = model.CourseTitle;
			ViewBag.CourseDescription = model.CourseDescription;
			return View();
		}
		public IActionResult EditCourse1(AdminModel model)
		{
			bool IsSuccess = manageCourseBALBase.PR_COURSE_UPDATE(model);
			return RedirectToAction("ManageCourse");
		}
		#endregion

		#region DeleteCourse
		public IActionResult DeleteCourse(int CourseID)
		{
			bool IsSuccess = manageCourseBALBase.PR_COURSE_DELETE(CourseID);
			return RedirectToAction("ManageCourse");
		}
		#endregion

		#region SearchCourse
		public IActionResult SearchCourse(AdminModel model)
		{
			List<AdminModel> model1 = manageCourseBALBase.PR_COURSE_SEARCH(model);
			return View("ManageCourse", model1);
		}
		#endregion

		#region ViewCourse
		public IActionResult ViewCourse(int CourseID)
		{
			AdminModel model = manageCourseBALBase.PR_COURSE_SELECTBYPK(CourseID);
			ViewBag.CourseID = model.CourseID;
			ViewBag.CourseCategoryID = model.CourseCategoryID;
			ViewBag.CourseCategory = model.CourseCategory;
			ViewBag.CourseName = model.CourseName;
			ViewBag.CourseLogo = model.CourseLogo;
			ViewBag.CourseTitle = model.CourseTitle;
			ViewBag.CourseDescription = model.CourseDescription;
			ViewBag.Created = model.Created;
			ViewBag.Modified = model.Modified;
			return View();
		}
		#endregion

		#region CourseCategoryDropDown
		public IActionResult CourseCategoryDropDown() 
		{
			List<AdminModel> adminModels = manageCourseBALBase.PR_COURSECATEGORY_DROPDOWN();
			ViewBag.CourseCategoryList = adminModels;
			return RedirectToAction("ManageCourse");	
		}
		#endregion



		#region ManageCourseContent
		public IActionResult ManageCourseContent()
		{

			List<AdminModel> adminModels = manageCourseContentBALBase.PR_COURSE_SELECTALL();
			return View(adminModels);
		}
		#endregion

		#region AddContent
		public IActionResult AddContent(int CourseID)
		{
			ViewBag.CourseID = CourseID;	
			return View();
		}
		#endregion

		#region ViewContent
		public IActionResult ViewContent()
		{
			return View();
		}
		#endregion

		#region SearchCourse1
		public IActionResult SearchCourse1(AdminModel model)
		{
			List<AdminModel> model1 = manageCourseContentBALBase.PR_COURSE_SEARCH(model);
			return View("ManageCourseContent", model1);
		}
		#endregion



		#region ManageUsers
		public IActionResult ManageUsers()
        {
            List<AdminModel> adminModels = manageUserBALBase.PR_USER_SELECTALLUSER();
            return View(adminModels);
        }
		#endregion

		#region AddNewUser
		public IActionResult AddNewUser()
		{
			return View();
		}
		public IActionResult AddNewUser1(AdminModel model)
		{
			bool IsSuccess = manageUserBALBase.PR_USER_INSERT(model);
			return RedirectToAction("ManageUsers");
		}
		#endregion

		#region SearchUser
		public IActionResult SearchUser(AdminModel model)
		{
			List<AdminModel> model1 = manageUserBALBase.PR_USER_SEARCH(model);
			return View("ManageUsers", model1);
		}
		#endregion

		#region ViewUserDetails
		public IActionResult ViewUserDetails(int UserID)
		{
			AdminModel model1 = manageUserBALBase.PR_USER_SELECTBYPK(UserID);
			ViewBag.UserID = model1.UserID;
			ViewBag.UserName = model1.UserName;
			ViewBag.UserEmail = model1.UserEmail;
			ViewBag.UserPassword = model1.UserPassword;
			ViewBag.UserContact = model1.UserContact;
			ViewBag.UserProfileImageURL = model1.UserProfileImageURL;
			ViewBag.IsActive = model1.IsActive;
			ViewBag.IsAdmin = model1.IsAdmin;
			ViewBag.Created = model1.Created;
			ViewBag.Modified = model1.Modified;

			AdminModel model2 = dashboardCountsBALBase.PR_ADMIN_DASHBOARD_COUNTS();
			ViewBag.CoursesCount = model2.CoursesCount;

			return View();
		}
		#endregion



		#region ManageTutorial
		public IActionResult ManageTutorial()
        {
            return View();
        }
        #endregion

        #region DEMO
        public IActionResult DEMO()
        {
            return View();
        }
		#endregion

	}
}
