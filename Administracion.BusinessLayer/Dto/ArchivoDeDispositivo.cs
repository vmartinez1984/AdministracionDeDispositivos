using System;

namespace Administracion.BusinessLayer.Dto
{
    public class ArchivoDeDispositivo
    {
        public int Id { get; set; }
        public string TipoDeArchivo { get; set; }        
        public string Base64 { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public bool IsActivo { get; set; }
    }
}