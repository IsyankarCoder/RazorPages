using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AuthAndAuthroizeRazor.Pages.Account
{
    public class LoginPage : PageModel
    {
        
        [BindProperty]
         public Credential Credential {get;set;}
        private readonly ILogger<LoginPage> _logger;

        public LoginPage(ILogger<LoginPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult>  OnPostAsync(){
             if(!ModelState.IsValid)
             return Page();
             
             if(Credential.Username=="admin" && Credential.Password=="123456"){
                var claims = new List<Claim>(){
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Email,"admin@mywebsite.com")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme,claimsPrincipal);
                return RedirectToPage("/Index");

             }

             return Page();
        }
    }
        public class Credential{
        
         [Required]
         [DataType(DataType.Password)]
        public string Password{get;set;}
        
        [Required]
        public string Username{get;set;}
        }
}