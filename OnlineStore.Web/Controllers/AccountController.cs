using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.ApiServices.Interfaces;
using OnlineStore.Web.Models;
using OnlineStore.Web.Models.Requests;
using System.Diagnostics;

namespace OnlineStore.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(ObtenerTokenRequest request)
        {

            var result = await this.authService.ObtenerTokenUsuario(request);

            if (!result.success) { 
                ViewBag.Message = result.message;

            return View("Error");
            }

            if (result.data != null && result.data.token != null)
            {
                // guardar la informacion del token //
               base.SaveSessionToken(result.data.token);
            }

            else
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Producto");
        }

        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel();
            errorViewModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(errorViewModel);
        }
    }
}
