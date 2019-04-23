using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store)
		: base(store)
		{
		}

		// this method is called by Owin therefore best place to configure your User Manager
		public static ApplicationUserManager Create(
			IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var manager = new ApplicationUserManager(
				new UserStore<ApplicationUser>(context.Get<VidlyContext>()));

			// Configure validation logic for usernames
			//manager.UserValidator = new UserValidator<ApplicationUser>(manager)
			//{
			//	AllowOnlyAlphanumericUserNames = false,
			//	RequireUniqueEmail = true
			//};

			// Configure validation logic for passwords
			//manager.PasswordValidator = new PasswordValidator
			//{
			//	RequiredLength = 6,
			//	RequireNonLetterOrDigit = true,
			//	RequireDigit = true,
			//	RequireLowercase = true,
			//	RequireUppercase = true,
			//};

			// Configure user lockout defaults
			//manager.UserLockoutEnabledByDefault = true;
			//manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			//manager.MaxFailedAccessAttemptsBeforeLockout = 5;

			return manager;
		}
	}
}