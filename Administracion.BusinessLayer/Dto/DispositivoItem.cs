using System.ComponentModel;

namespace Administracion.BusinessLayer.Dto
{
    public class DispositivoItem
    {
        public int Id { get; set; }

        [DisplayName("Tipo de dispositivo")]
        public string TipoDeDispositivoNombre { get; set; }

        [DisplayName("Clave")]
        public string AgenciaClave { get; set; }

        [DisplayName("Agencia")]
        public string AgenciaNombre { get; set; }

        [DisplayName("Número de serie")]
        public string NumeroDeSerie { get; set; }
                
        public string Comentarios { get; set; }

        [DisplayName("Estatus del dispositivo")]
        public string EstatusDelDispositivoNombre { get; set; }
    }
}