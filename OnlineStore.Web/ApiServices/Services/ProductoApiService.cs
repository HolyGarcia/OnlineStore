using Newtonsoft.Json;
using OnlineStore.Web.ApiServices.Interfaces;
using OnlineStore.Web.Models.Requests;
using OnlineStore.Web.Models.Responses;
using System.Text;

namespace OnlineStore.Web.ApiServices.Services
{
    public class ProductoApiService : IProductoApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductoApiService> logger;
        private readonly string baseUrl;


        private string _token;

        public ProductoApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<ProductoApiService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];


        }

        public string Token
        {
            get;
            set;

        }

        public async Task<ProductoGetResponse> GetProducto(int Id)
        {
            ProductoGetResponse productoGet = new ProductoGetResponse();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {



                    string url = $" {this.baseUrl}/Product/{Id}";

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            productoGet = JsonConvert.DeserializeObject<ProductoGetResponse>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                productoGet.success = false;
                productoGet.message = this.configuration["ProductErrorMessage:GetProducto"];
                this.logger.LogError(productoGet.message, ex.ToString());

            }
            return productoGet;
        }

        public async Task<ProductoListResponse> GetProductos()
        {
            ProductoListResponse productoList = new ProductoListResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Product";

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            productoList = JsonConvert.DeserializeObject<ProductoListResponse>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                productoList.success = false;
                productoList.message = this.configuration["ProductErrorMessage:GetProductos"];
                this.logger.LogError(productoList.message, ex.ToString());
            }

            return productoList;
        }

        public async Task<ProductoAddReponse> SaveProducto(ProductoSaveRequest productRequest)
        {
            ProductoAddReponse result = new ProductoAddReponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Product/SaveProduct";

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");

                    StringContent request = new StringContent(JsonConvert.SerializeObject(productRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductoAddReponse>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = this.configuration["ProductErrorMessage:Save"];
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }

        public async Task<ResponseBase> UpdateProducto(ProductoSaveRequest productoRequest)
        {
            ResponseBase result = new ResponseBase();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Product/UpdateProduct";

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");

                    StringContent request = new StringContent(JsonConvert.SerializeObject(productoRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ResponseBase>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = this.configuration["ProductErrorMessage:Update"];
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }
    }
}
