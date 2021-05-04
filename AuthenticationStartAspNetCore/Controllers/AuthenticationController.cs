using AuthenticationStartAspNetCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance.EFContext;
using Persistance.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace VerifikacijaMjerila.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly MyDbContext _db;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AuthenticationController(ILogger<AuthenticationController> logger, UserManager<Korisnik> userManager, SignInManager<Korisnik> signInManager, MyDbContext db, RoleManager<IdentityRole<int>> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string message, string ReturnUrl = "/")
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index");
            if (message == "nup")
                message = "Netačno korisničko ime ili lozinka.";
            TempData["message"] = message;
            TempData["returnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password, string remember, string ReturnUrl)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index");
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                user = await _userManager.FindByEmailAsync(username);

            if (user != null && !string.IsNullOrWhiteSpace(password))
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, remember == "on", false);
                if (signInResult.Succeeded)
                    return Redirect(ReturnUrl);
                else if (signInResult.IsNotAllowed)
                    return Redirect("/Home/Login?message=Nalog nije aktiviran.");
            }
            return Redirect("/Authentication/Login?message=nup");
        }
        [HttpGet]
        public async Task<IActionResult> Registration(string usernameError, string passwordError)
        {
            //if (_signInManager.IsSignedIn(User))
            //    return Redirect("/Home/Index");
            if (!string.IsNullOrWhiteSpace(usernameError))
                ModelState.AddModelError("Username", usernameError);
            if (!string.IsNullOrWhiteSpace(passwordError))
                ModelState.AddModelError("Password", passwordError);
            if (!await _roleManager.RoleExistsAsync("Gost"))
                await _roleManager.CreateAsync(new IdentityRole<int>("Gost"));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(string username, string password, string firstName, string lastName, string email, string mobileNumber)
        {
            //if (_signInManager.IsSignedIn(User))
            //    return Redirect("/Home/Index");
            var result = await _userManager.CreateAsync(new Korisnik { UserName = username, Email = email, PhoneNumber = mobileNumber, Ime = firstName, Prezime = lastName }, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(username), "Gost");
                return Redirect("/Home/Index");
            }
            else if (result.Errors.Count() > 0)
            {
                string usernameError = "";
                string passwordError = "";
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                        usernameError = "Korisničko ime već postoji.";
                    else
                    {
                        passwordError = "Lozinka mora sadržavati minimalno 6 karaktera, od čega minimalno jedno malo slovo, jedno veliko, jedan znak i jedan broj .";
                    }
                }
                return Redirect("/Home/Registration?usernameError=" + usernameError + "&passwordError=" + passwordError);
            }
            return BadRequest();
        }
        [Authorize]
        public async Task<IActionResult> UrediProfil(int Id)
        {
            AuthenticationUrediProfilVM model = await _db.Users.Select(x => new AuthenticationUrediProfilVM
            {
                Id = x.Id,
                Email = x.Email,
                Ime = x.Ime,
                KorisnickoIme = x.UserName,
                Prezime = x.Prezime,
                Telefon = x.PhoneNumber
            }).FirstOrDefaultAsync(x => x.Id == Id);
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Snimi([FromBody] AuthenticationUrediProfilVM korisnik)
        {
            var k = await _db.Users.FirstOrDefaultAsync(x => x.Id == korisnik.Id);
            if (k == null)
                return NotFound();

            k.Ime = korisnik.Ime;
            k.Prezime = korisnik.Prezime;
            if (k.UserName != korisnik.KorisnickoIme)
            {
                string usernameError = "";
                var izmjernaKorisnickogImena = await _userManager.SetUserNameAsync(k, korisnik.KorisnickoIme);
                if (!izmjernaKorisnickogImena.Succeeded)
                    usernameError = "Korisničko ime već postoji.";
                if (!string.IsNullOrWhiteSpace(usernameError))
                    return BadRequest(usernameError);
            }
            if (k.Email != korisnik.Email)
            {
                var izmjenaEmaila = await _userManager.ChangeEmailAsync(k, korisnik.Email, await _userManager.GenerateChangeEmailTokenAsync(k, korisnik.Email));
                if (!izmjenaEmaila.Succeeded)
                {
                    string emailError = "";
                    foreach (var error in izmjenaEmaila.Errors)
                    {
                        if (error.Code == "InvalidEmail")
                            emailError = "Email netačnog formata.";
                        else if (error.Code == "DuplicateEmail")
                            emailError = "Email već postoji.";
                    }
                    if (!string.IsNullOrWhiteSpace(emailError))
                        return BadRequest(emailError);
                }
            }

            if (k.PhoneNumber != korisnik.Telefon)
                await _userManager.ChangePhoneNumberAsync(k, korisnik.Telefon, await _userManager.GenerateChangePhoneNumberTokenAsync(k, korisnik.Telefon));

            if (!string.IsNullOrWhiteSpace(korisnik.Lozinka))
            {
                var promjenaLozinke = await _userManager.ResetPasswordAsync(k, await _userManager.GeneratePasswordResetTokenAsync(k), korisnik.Lozinka);
                if (!promjenaLozinke.Succeeded)
                    return Ok("Lozinka mora sadržavati minimalno 6 karaktera, od čega minimalno jedno veliko slovo i jedan broj.");
            }
            await _db.SaveChangesAsync();
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(k, true);
            return Ok();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View("NotAuthorized");
        }
    }
}
