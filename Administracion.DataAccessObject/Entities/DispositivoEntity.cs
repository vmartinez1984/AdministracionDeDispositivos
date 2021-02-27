namespace Administracion.DataAccessObject.Entities
{
    public class DispositivoEntity:BaseFechaBajaYEdicionEntity
    {
        public int AgenciaId { get; set; }
        public int TipoDeDispositivoId { get; set; }
        public int UsuarioId { get; set; }
        public string NumeroDeSerie { get; set; }
        public string Comentarios { get; set; }
        public string Bitacora { get; set; }
        public int EstatusDelDispositivoId { get; set; }
    }
}