namespace Administracion.DataAccessObject.Entities
{
    public class DispositivoItemEntity
    {
        public int Id { get; set; }
        public string TipoDeDispositivoNombre { get; set; }
        public string AgenciaClave { get; set; }
        public string AgenciaNombre { get; set; }
        public string NumeroDeSerie { get; set; }
        public string Comentarios { get; set; }
        public string EstatusDelDispositivoNombre { get; set; }
    }
}