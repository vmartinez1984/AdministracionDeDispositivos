using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class TipoDeDispositivo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
