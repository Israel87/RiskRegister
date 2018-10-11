using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using RiskRegister.Models;
using RiskRegisterII.Data;
using RiskRegisterII.Models;
using RiskRegisterII.Services;

namespace RiskRegister.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserManager _userManager;

        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entry()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var isValid = _userManager.Authenticate(loginModel.Email, loginModel.Password);

            if (!isValid)
            {
                ModelState.AddModelError("", "Invalid username and /or password");
                return View();
            }

            var user = _userManager.GetUser(loginModel.Email);
            var userDetail = _userManager.GetUserDetailByUserID(user.ID);
            var roles = _userManager.GetUserRoles(user.ID);
            // get user profile details 

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, (userDetail?.Lastname + " " +((userDetail?.FirstName!="")? userDetail.FirstName[0]+ ".": "") + ((userDetail?.MiddleName!="")? userDetail.MiddleName[0] + ".": "") )),
                new Claim(ClaimTypes.Email, ((userDetail?.Email!=null)?userDetail.Email:user.Username)),
                new Claim("USERNAME", user.Username),
                new Claim("ID", user.ID.ToString()),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault().Name),

            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "cookie");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Sign in
            await HttpContext.SignInAsync(
                scheme: "RiskManagement", 
                principal: claimsPrincipal);

            if (claimsPrincipal.IsInRole("SuperAdmin"))
            {
                return RedirectToAction("Entry", "Home");
            }
            else
            {
              return RedirectToAction("Index", "ErrorRegister");
            }

        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(scheme: "RiskManagement");
            return View("index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

