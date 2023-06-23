
using System.Collections.Generic;


namespace OnlineStore.Infraestructure.Models
{
    public class ProductoCategoriaModel
    {
        public ProductoCategoriaModel() 
        { 
           this.ProductoModel = new ProductoModel();
            this.CategoriaModel = new List<CategoriaModel>();
        }

        public ProductoModel? ProductoModel { get; set; }
        public List<CategoriaModel> CategoriaModel { get; set;}

    }
}
