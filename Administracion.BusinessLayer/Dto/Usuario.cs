using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("Usuario")]
        public string NombreDeUsuario { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        [MaxLength(20)]
        public string Contrasenia { get; set; }

        [Required]
        [DisplayName("Perfil")]
        public int PerfilId { get; set; }

        public bool IsActivo { get; set; }
    }
}