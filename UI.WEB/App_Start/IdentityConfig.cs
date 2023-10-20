using Core.Concrates.Entities.Account;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.WEB.App_Start
{

    public class SMSService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //SMS Gönderme servisi buraya yazılacak.
            return Task.FromResult(0);
        }
    }

    public class EMailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //E-Posta Gönderme servisi buraya yazılacak.
            return Task.FromResult(0);
        }
    }




    public class AppSignInManager : SignInManager<User, string>
    {
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.CreateUserIdentityAsync((AppUserManager)UserManager);
        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options, IOwinContext context)
        {
            return new AppSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }

        public class AppUserManager : UserManager<User, string>
        {
            public AppUserManager(IUserStore<User, string> store) : base(store) { }

            public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
            {
                var manager = new AppUserManager(new UserStore<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(context.Get<AccountContext>()));
                manager.UserValidator = new UserValidator<User>(manager)
                {
                    AllowOnlyAlphanumericUserNames = true,
                    RequireUniqueEmail = true
                };

                manager.PasswordValidator = new PasswordValidator()
                {
                    RequiredLength = 8,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true
                };
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 3;

                manager.RegisterTwoFactorProvider("Phone", new PhoneNumberTokenProvider<User> { MessageFormat = "Security code {0}" });
                manager.SmsService = new SMSService();

                manager.RegisterTwoFactorProvider("Email", new EmailTokenProvider<User> { BodyFormat = "Security code {0}" });
                manager.EmailService = new EMailService();

                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
                }

                return manager;

            }
        }
    }
}