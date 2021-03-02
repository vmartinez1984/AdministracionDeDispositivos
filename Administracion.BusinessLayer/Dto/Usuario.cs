using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Administracion.BusinessLayer.Dto
{
    public class Usuario:IPrincipal
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

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Identidad : IIdentity
    {
        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}