using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.ViewModels;

namespace ShoppingCart.Controllers
{
        public class AccountController : Controller
        {
                private UserManager<AppUser> _userManager;
                private SignInManager<AppUser> _signInManager;

                public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
                {
                        _userManager = userManager;
                        _signInManager = signInManager;
                }

                public IActionResult Create() => View();

                [HttpPost]
                public async Task<IActionResult> Create(User user)
                {
                        if (ModelState.IsValid)
                        {
                                AppUser newUser = new AppUser { UserName = user.UserName, Email = user.Email };
                                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                                if (result.Succeeded)
                                {
                                        return Redirect("/admin/products");
                                }

                                foreach (IdentityError error in result.Errors)
                                {
                                        ModelState.AddModelError("", error.Description);
                                }

                        }

                        return View(user);
                }

                public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl });

                [HttpPost]
                public async Task<IActionResult> Login(LoginViewModel loginVM)
                {
                        if (ModelState.IsValid)
                        {
                                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);

                                if (result.Succeeded)
                                {
                                        return Redirect(loginVM.ReturnUrl ?? "/");
                                }

                                ModelState.AddModelError("", "Invalid username or password");
                        }

                        return View(loginVM);
                }

                public async Task<RedirectResult> Logout(string returnUrl = "/")
                {
                        await _signInManager.SignOutAsync();

                        return Redirect(returnUrl);
                }

        }
}
