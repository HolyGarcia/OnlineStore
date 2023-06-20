using Microsoft.AspNetCore.Mvc;
using OnlineStore.Web.ApiServices.Interfaces;
using OnlineStore.Web.Models.Requests;
using OnlineStore.Web.Models.Responses;

namespace OnlineStore.Web.Controllers
{
    public class ProductoController : BaseController
    {
        private readonly IProductoApiService productoApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductoController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public ProductoController(IProductoApiService productoApiService,
                                  IConfiguration configuration,
                                  ILogger<ProductoController> logger)
        {
            this.productoApiService = productoApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
            ProductoListResponse productoList = new ProductoListResponse();

            try
            {

                this.productoApiService.Token = base.GetToken();
                productoList = await this.productoApiService.GetProductos();


            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(productoList.data);
        }

        // GET: ProductoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ProductoGetResponse productoGet = new ProductoGetResponse();

            try
            {
                var token = HttpContext.Session.GetString("myToken");

                productoGet = await this.productoApiService.GetProducto(id);


            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(productoGet.data);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoSaveRequest productoSave)
        {
            try
            {

                var result = await this.productoApiService.SaveProducto(productoSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var productoGet = await this.productoApiService.GetProducto(id);

            ProductoSaveRequest productoSave = new ProductoSaveRequest()
            {
               
                descripcion = productoGet.data.descripcion,
                marca = productoGet.data.marca,
                nombreImagen = productoGet.data.nombreImagen,
                precio = productoGet.data.precio,
                stock = productoGet.data.stock,
                urlImagen = productoGet.data.urlImagen,
                productoId = productoGet.data.productoId

            };


            return View(productoSave);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductoSaveRequest productSave)
        {
            try
            {

                await this.productoApiService.UpdateProducto(productSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5

    }
}
