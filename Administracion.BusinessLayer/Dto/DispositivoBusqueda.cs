using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Administracion.BusinessLayer.Dto
{
    public class DispositivoBusqueda
    {
        [DisplayName("Tipo de dispositivo")]
        public int? TipoDeDispositivoId { get; set; }

        [DisplayName("Agencia")]
        public int? AgenciaId { get; set; }

        [DisplayName("Proyecto")]
        public int? ProyectoId { get; set; }

        [MaxLength(50)]
        [DisplayName("Número de serie")]
        public string NumeroDeSerie { get; set; }

        [MaxLength(50)]
        [DisplayName("Licencia")]
        public string Licencia { get; set; }


        [DisplayName("Estatus del dispositivo")]
        public int? EstatusDelDispositivoId { get; set; }
    }
}