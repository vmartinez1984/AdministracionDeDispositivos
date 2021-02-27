using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class CatalogoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es un campo necesario")]
        [MaxLength(20, ErrorMessage = "El nombre es demasiado largo, solo 20 caracteres")]
        public string Nombre { get; set; }
    }
}