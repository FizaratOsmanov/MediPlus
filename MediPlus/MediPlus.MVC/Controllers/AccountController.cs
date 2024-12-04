using MediPlus.BL.Utilities;
using MediPlus.DAL.Contexts;
using MediPlus.DAL.DTOs.UserDTOs;
using MediPlus.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MediPlus.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly MediPlusDbContext _mediPlusDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(MediPlusDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _mediPlusDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(CreateUserDTO createUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(createUserDTO);
            }
            AppUser user = new AppUser();
            user.FirstName = createUserDTO.FirstName;
            user.LastName = createUserDTO.LastName;
            user.Email = createUserDTO.Email;
            user.UserName = createUserDTO.Username;
            var result = await _userManager.CreateAsync(user, createUserDTO.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(createUserDTO);
            }
            _userManager.AddToRoleAsync(user, "User");
            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser? user = await _userManager.FindByEmailAsync(loginUserDTO.EmailOrUsername);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginUserDTO.EmailOrUsername);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Username or Password is incorrect");
                    return View();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginUserDTO.Password, loginUserDTO.IsPersistant, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return View();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        //public async Task CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole {Name = "Admin"});
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });

        //}
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user=new AppUser();
            user.UserName = "SuperAdmin";
            user.Email = "admin@mediplus.com";
            user.FirstName = "Fizaret";
            user.LastName = "Osmanov";


            var result=await _userManager.CreateAsync(user,"Admin123!");
            if (!result.Succeeded)
            {
                return Json(result);
            }
            await _userManager.AddToRoleAsync(user,RoleEnums.Admin.ToString());

             return View();
        }
    }
}
    
