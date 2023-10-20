using Core.Abstracts.Services.Data;
using Core.Abstracts.Services.Game;
using System.Web;
using System.Web.Mvc;
using UI.WEB.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Services01;
using Services01.Game;
using System.Threading.Tasks;
using UI.WEB.Models;
using Core.Concrates.DTOs.Data;
using Core.Concrates.DTOs.Game;
using Core.Concrates.Entities.Account;
using static UI.WEB.App_Start.AppSignInManager;

namespace UI.WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IArticleService _aService;
        private IGameService _pService;
        

        private AppSignInManager _signInManager;
        public AppSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<AppSignInManager>();
            set => _signInManager = value;
        }

        private AppUserManager _userManager;


        public AppUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().Get<AppUserManager>();
            set => _userManager = value;
        }
        public AccountController()
        {
            _aService = ArticleService.Create();
            _pService = GameService.Create();

        }

        public AccountController(AppSignInManager signInManager, AppUserManager userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _aService = ArticleService.Create();
            _pService = GameService.Create();
        }

        // GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginResponse = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            switch (loginResponse)
            {
                case SignInStatus.Success:
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendVerification", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.LockedOut:
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Login Attempt Fail");
                    return View(model);
            }
        }

        //public ActionResult Logout()
        //{
        //    return View();
        //}

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    AuthorDTO author = new AuthorDTO
                    {
                        Name = $"{model.FirstName} {model.LastName}"
                    };
                    await _aService.AddAuthor(author, user.Id);

                    PlayerDTO player = new PlayerDTO
                    {
                        Name = model.UserName
                    };
                    await _pService.AddPlayer(player, user.Id);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        //public ActionResult AccessDenied()
        //{
        //    return View();
        //}

    }
}