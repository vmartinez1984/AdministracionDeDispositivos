namespace Administracion.DataAccessObject.Entities
{
    public class ArchivoDelDispositivoEntity : BaseEntity
    {
        public string RutaDelArchivo { get; set; }
        public int DispositivoId { get; set; }
    }
}