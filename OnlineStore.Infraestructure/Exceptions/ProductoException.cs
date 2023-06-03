using System;

namespace OnlineStore.Infraestructure.Exceptions
{
    public class ProductoException : Exception
    {
        public ProductoException(string message) : base(message)
        {
        }
    }
}
