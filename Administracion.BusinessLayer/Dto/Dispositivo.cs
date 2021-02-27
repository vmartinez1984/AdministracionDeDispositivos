using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class Dispositivo
    {        
        public int Id { get; set; }

        [Required]
        [DisplayName("Tipo de dispositivo")]
        public int TipoDeDispositivoId { get; set; }

        [Required]
        [DisplayName("Agencia")]
        public int AgenciaId { get; set; }

        public int ProyectoId { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Número de serie")]
        public string NumeroDeSerie { get; set; }

        [MaxLength(250)]        
        public string Comentarios { get; set; }

        
        [DisplayName("Estatus del dispositivo")]
        public int EstatusDelDispositivoId { get; set; }

        public List<ArchivoDeDispositivo> ListaDeArchivos { get; set; }

        public int UsuarioId { get; set; }
    }
}