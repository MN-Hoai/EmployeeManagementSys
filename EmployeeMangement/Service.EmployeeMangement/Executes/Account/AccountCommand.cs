using DBContext.EmployeeMangement;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Service.EmployeeMangement.Executes.Account;
=======
using Service.EmployeeMangement.Executes;
>>>>>>> main
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Service.EmployeeMangement.Executes.Account
=======
namespace Service.EmployeeMangement.Executes
>>>>>>> main
{
    public class AccountCommand
    {
        private readonly EmployeeManagementContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountCommand(EmployeeManagementContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<bool> CheckAccount (AccountModel.AccountRequest request)
        {
            if (request == null) {
                return false;
            }

            var account = await _context.Employees.
                FirstOrDefaultAsync(x => x.Email  == request.Email && x.PasswordHash == request.PasswordHash);

            if (account == null) {
                return false;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim("fullname", account.Fullname)
            }; 

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            };

            var context = _httpContextAccessor.HttpContext;
            await context.SignInAsync(
                "Cookies",
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
            return true;



        }
    }
}







