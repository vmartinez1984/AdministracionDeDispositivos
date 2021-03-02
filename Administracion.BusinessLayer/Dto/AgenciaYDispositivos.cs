using System.ComponentModel;

namespace Administracion.BusinessLayer.Dto
{
    public class AgenciaYDispositivos
    {
        public string AgenciaClave { get; set; }
        public string AgenciaNombre { get; set; }
        public string AgenciaTipo { get; set; }
        public string Ciudad { get; set; }
        [DisplayName("AT9000")]
        public string Dispositivo1 { get; set; }
        [DisplayName("CSD200/CSD300")]
        public string Dispositivo2 { get; set; }
        [DisplayName("Logitech CS252")]
        public string Dispositivo3 { get; set; }
        [DisplayName("PentaDesko")]
        public string Dispositivo4 { get; set; }
        [DisplayName("Kojak")]
        public string Dispositivo5 { get; set; }
    }
}