using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Administracion.BusinessLayer.Dto
{
    public  class AgenciaDetalle
    {
        public int Id { get; set; }
        [DisplayName("Proyecto")]
        public string ProyectoNombre { get; set; }
        [DisplayName("Tipo de agencia")]
        public string TipoDeAgencia { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Comentarios { get; set; }
        [DisplayName("Fecha de registro")]
        public DateTime? FechaDeRegistro { get; set; }
        [DisplayName("Fecha de edicion")]
        public DateTime? FechaDeEdicion { get; set; }
        [DisplayName("Fecha de baja")]
        public DateTime? FechaDeBaja { get; set; }
        [DisplayName("Bitacora")]
        public List<AgenciaBitacora> ListaDeBitacora { get; set; }
    }
}