using Microsoft.Extensions.Logging;
using OnlineStore.Domain.Entities.Almacen;
using OnlineStore.Infraestructure.Context;
using OnlineStore.Infraestructure.Core;
using OnlineStore.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace OnlineStore.Infraestructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, IcategoriaRepository
    {
        private readonly SaleContext context;
        private readonly ILogger<CategoriaRepository> logger;
        public CategoriaRepository(SaleContext context, ILogger<CategoriaRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        
    }
}
