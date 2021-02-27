namespace Administracion.DataAccessObject.Entities
{
    public class AgenciaEntity: BaseFechaBajaYEdicionEntity
    {
        public int ProyectoId { get; set; }
        public int TipoDeAgenciaId { get; set; }
        public int? EstadoId { get; set; }
        public string Clave { get; set; }
        public string Ciudad { get; set; }
        public string Comentarios { get; set; }
        public string Bitacora { get; set; }
        public int UsuarioId { get; set; }
    }
}