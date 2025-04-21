using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Areas.User.Models
{
    public class UserModel
    {
        public string userCode { get; set; }
		public int UserID { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		public string UserEmail { get; set; }

		[Required]
		public string UserPassword { get; set; }

		[Required]
		public string UserContact { get; set; }

		[Required]
		public string UserProfileImageURL { get; set; }

		[Required]
		public bool IsActive { get; set; }

		[Required]
		public bool IsAdmin { get; set; }

		[Required]
		public string Created { get; set; }

		[Required]
		public string Modified { get; set; }





		public int CourseCategoryID { get; set; }

		[Required]
		public string CourseCategory { get; set; }





		public int CourseID { get; set; }

		[Required]
		public string CourseName { get; set; }

		[Required]
		public string CourseLogo { get; set; }

		[Required]
		public string CourseTitle { get; set; }

		[Required]
		public string CourseDescription { get; set; }






		[Required]
		public int AdminsCount { get; set; }

		[Required]
		public int UsersCount { get; set; }

		[Required]
		public int CourseCategoryCount { get; set; }

		[Required]
		public int CoursesCount { get; set; }

	}
}
