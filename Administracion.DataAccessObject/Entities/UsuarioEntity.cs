using System;

namespace Administracion.DataAccessObject.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public int PerfilId { get; set; }
        public string PerfilNombre { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Contrasenia { get; set; }
        public DateTime? FechaDeBaja { get; set; }
    }
}
