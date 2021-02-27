using System.ComponentModel;

namespace Administracion.BusinessLayer.Dto
{
    public class DispositivoBitacora
    {
        public string TipoDeDispositivoNombre { get; set; }

        [DisplayName("Agencia")]
        public string AgenciaNombre { get; set; }

        public string ProtectoNombre { get; set; }

        [DisplayName("Número de serie")]
        public string NumeroDeSerie { get; set; }
                
        public string Comentarios { get; set; }

        [DisplayName("Estatus del dispositivo")]
        public string EstatusDelDispositivo { get; set; }

        [DisplayName("Usuario")]
        public string Usuario { get; set; }
    }
}