﻿

using OnlineStore.Domain.Core;

namespace OnlineStore.Domain.Entities.Seguridad
{
    public class Roles : BaseEntity
    {
        public int Id { get; set; }
        public string? Descripcion {get; set;} 
    }
}
