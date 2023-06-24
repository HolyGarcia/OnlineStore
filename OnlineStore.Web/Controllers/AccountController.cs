using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.ApiServices.Interfaces;
using OnlineStore.Web.Models.Requests;

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

            if (!result.success)
                ViewBag.Message = result.message;

            // guardar la informacion del token //
            base.SaveSessionToken(result.data.token);

            return RedirectToAction("Index", "Producto");
        }
    }
}
