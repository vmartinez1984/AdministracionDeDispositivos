namespace Administracion.DataAccessObject.Entities
{
    public class AgenciaItemEntity
    {
        public int Id { get; set; }
        public string ProyectoNombre { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string TipoDeAgencia { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }
    }
}