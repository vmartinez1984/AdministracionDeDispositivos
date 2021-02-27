using System.ComponentModel;

namespace Administracion.BusinessLayer.Dto
{
    public  class UsuarioItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Perfil")]
        public string PerfilNombre { get; set; }
    }
}