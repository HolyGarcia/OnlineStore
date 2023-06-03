
using System;

namespace OnlineStore.Domain.Core
{
    public abstract class BaseEntity
    {
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioMod { get; set; }
        public DateTime FechaMod { get; set; }
        public int idUsuarioElimino { get; set; }
        public DateTime FechaElimino { get; set;}
        public bool Eliminado { get; set; }
        public bool EsActivo { get;set; }

    }
}
