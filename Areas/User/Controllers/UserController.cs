using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis;
using System.Reflection;
using WebApplication7.Areas.User.Models;
using WebApplication7.BAL;

namespace WebApplication7.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/User/{Action}")]
    public class UserController : Controller
    {
        DashboardCountsBALBase dashboardCountsBALBase = new DashboardCountsBALBase();
        ManageCourseCategoryBALBase manageCourseCategoryBALBase = new ManageCourseCategoryBALBase();    

		#region UserDashboard
		public IActionResult UserDashboard()
		{
			AdminModel model = dashboardCountsBALBase.PR_USER_DASHBOARD_COUNTS();
			ViewBag.CourseCategoryCount = model.CourseCategoryCount;
			ViewBag.CoursesCount = model.CoursesCount;
			return View();
        }
        #endregion

        #region UserCourses
        public IActionResult UserCourses()
		{
			List<AdminModel> adminModels = manageCourseCategoryBALBase.PR_COURSECATEGORY_SELECTALL();
			return View(adminModels);
        }
		#endregion

		#region UserProfile
		public IActionResult UserProfile()
        {
            return View();
        }
        #endregion

        #region UserTutorials
        public IActionResult UserTutorials()
        {
            return View();
        }
        #endregion

        #region UserExercises
        public IActionResult UserExercises()
        {
            return View();
        }
        #endregion
       
        #region UserContests
        public IActionResult UserContests()
        {
            return View();
        }
        #endregion

        #region UserCompiler
        public IActionResult UserCompiler()
        {
            return View();
        }

        public IActionResult UserCompiler1(UserModel model)
        {
            try
            {
                // Compile and run the code
                string result = CompileAndRunCode(model.userCode);

                ViewBag.Result = result;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
            }

            return View(model);
        }

        private string CompileAndRunCode(string code)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

            CSharpCompilation compilation = CSharpCompilation.Create(
                "DynamicAssembly",
                new[] { syntaxTree },
                references: new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
                options: new CSharpCompilationOptions(OutputKind.ConsoleApplication)
            );

            using (var ms = new System.IO.MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (result.Success)
                {
                    ms.Seek(0, System.IO.SeekOrigin.Begin);

                    Assembly assembly = Assembly.Load(ms.ToArray());

                    // Attempt to find an entry point (Main method)
                    MethodInfo entryPoint = assembly.EntryPoint;
                    if (entryPoint != null)
                    {
                        object[] args = null;

                        if (entryPoint.GetParameters().Length > 0)
                        {
                            args = new object[] { new string[] { } }; // Pass any required parameters
                        }

                        object resultObj = entryPoint.Invoke(null, args);

                        return "" + resultObj;
                    }
                    else
                    {
                        throw new InvalidOperationException("No entry point (Main method) found in the compiled assembly.");
                    }
                }
                else
                {
                    // Handle compilation errors
                    string errors = string.Join(Environment.NewLine, result.Diagnostics);
                    throw new InvalidOperationException("Compilation failed with errors:" + Environment.NewLine + errors);
                }
            }
        }
        #endregion

    }
}