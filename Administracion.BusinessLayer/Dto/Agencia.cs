using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class Agencia
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Proyecto")]
        public int ProyectoId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(10)]
        public string Clave { get; set; }

        [Required]
        [DisplayName("Tipo de agencia")]
        public int TipoDeAgenciaId { get; set; }

        [MaxLength(250)]
        public string Ciudad { get; set; }

        [Required]
        [DisplayName("Estado")]
        public int EstadoId { get; set; }

        [MaxLength(250)]
        public string Comentarios { get; set; }

        public int UsuarioId { get; set; }
    }
}