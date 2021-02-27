using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Administracion.BusinessLayer.Dto
{
    public class DispositivoDetalle
    {
        public int Id { get; set; }

        [DisplayName("Tipo de dispositivo")]
        public string TipoDeDispositivo { get; set; }

        [DisplayName("Agencia")]
        public string Agencia { get; set; }

        public string Proyecto { get; set; }

        [DisplayName("Número de serie")]
        public string NumeroDeSerie { get; set; }

        public string Comentarios { get; set; }

        [DisplayName("Fecha de registro")]
        public DateTime FechaDeRegistro { get; set; }

        [DisplayName("Estatus del dispositivo")]
        public string EstatusDelDispositivo { get; set; }

        public List<DispositivoBitacora> ListaDeBitacora { get; set; }

        public List<ArchivoDeDispositivo> ListaDeArchivos { get; set; }
    }
}