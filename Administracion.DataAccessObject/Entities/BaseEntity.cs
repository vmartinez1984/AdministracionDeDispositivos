using System;

namespace Administracion.DataAccessObject.Entities
{
    public class BaseEntity : CatalogoEntity
    {

        public DateTime FechaDeRegistro { get; set; }
        public bool IsActivo { get; set; }
    }
}
