using System;

namespace Administracion.DataAccessObject.Entities
{
    public class BaseFechaBajaYEdicionEntity : BaseEntity
    {
        public DateTime? FechaDeBaja { get; set; }
        public DateTime? FechaDeEdicion { get; set; }
    }
}