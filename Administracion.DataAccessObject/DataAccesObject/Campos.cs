namespace Administracion.DataAccessObject.DataAccesObject
{
    public class Campos
    {
       static string catalogo = $@" id,
            nombre";
        public static string Catalogo
        {
            get { return catalogo; }
        }
        public static string Base
        {
            get
            {
                return $@"{catalogo},
                fecha_de_registro FechaDeRegistro,
                is_activo IsActivo";
            }
        }

        public static string FechaDeBaja {
            get
            {
                return $@"fecha_de_baja FechaDeBaja";
            }
        }
    }
}
