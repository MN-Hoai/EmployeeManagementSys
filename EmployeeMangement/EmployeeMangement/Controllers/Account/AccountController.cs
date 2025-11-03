using CRUD_Product;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Service.EmployeeMangement.Executes.Account;
=======
using Service.EmployeeMangement.Executes;

>>>>>>> main
using System.Threading.Tasks;

namespace CRUD_Product.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountCommand _accountCommand;

        public AccountController(AccountCommand accountCommand)
        {
            _accountCommand = accountCommand;
        }

        // GET: /Account/SignIn
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        // POST: /Account/SignIn
        [HttpPost]
        public async Task<IActionResult> SignIn(AccountModel.AccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin đăng nhập.";
                return View(request);
            }

            var result = await _accountCommand.CheckAccount(request);

            if (!result)
            {
                ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View(request);
            }

            return RedirectToAction("List", "Employee");
        }

        //// GET: /Account/Logout
        //[HttpGet]
        //public async Task<IActionResult> Logout()
        //{
        //    await _accountCommand.Logout();
        //    return RedirectToAction("SignIn", "Account");
        //}
    }
}
