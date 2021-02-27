using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class UsuarioInicioDeSesion
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contrasenia { get; set; }
    }
}