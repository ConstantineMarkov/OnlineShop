using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public interface IAccountController
    {
        IActionResult Index();

        IActionResult Login();

        Task<IActionResult> Login(LoginViewModel user);

        Task<IActionResult> Logout();

        IActionResult Register();

        Task<IActionResult> Register(RegisterViewModel model);
    }
}