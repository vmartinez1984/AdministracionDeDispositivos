using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class AgenciaItem : CatalogoDto
    {
        [DisplayName("Proyecto")]
        public string ProyectoNombre { get; set; }

        public string Clave { get; set; }

        [DisplayName("Tipo de agencia")]
        public string TipoDeAgencia { get; set; }

        [MaxLength(250)]
        public string Ciudad { get; set; }

        [Required]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [MaxLength(250)]
        public string Comentarios { get; set; }
    }
}