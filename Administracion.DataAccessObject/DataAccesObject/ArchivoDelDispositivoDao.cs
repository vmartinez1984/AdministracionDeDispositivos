using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class ArchivoDelDispositivoDao
    {
        public static int Add(ArchivoDelDispositivoEntity entity)
        {
            try
            {
                string query;

                query = $@"
                INSERT INTO   archivo_del_dispositivo
                (
                    is_activo,
                    dispositivo_id,
                    ruta_del_archivo,
                    fecha_de_registro
                )
                VALUES
                (
                    1,      
                    @DispositivoId,
                    @RutaDelArchivo,
                    NOW()
                ); SELECT LAST_INSERT_ID();";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new
                    {
                        DispositivoId = entity.DispositivoId,
                        RutaDelArchivo = entity.RutaDelArchivo,
                    }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ArchivoDelDispositivoEntity> GetAll(int dispositivoId)
        {
            try
            {
                List<ArchivoDelDispositivoEntity> entities;
                string query;

                query = $@"
                SELECT 
                    id,
                    is_activo           IsActivo,
                    dispositivo_id      DisposotivoId,
                    ruta_del_archivo    RutaDelArchivo,
                    fecha_de_registro   FechaDeRegistro
                FROM archivo_del_dispositivo
                WHERE dispositivo_id = {dispositivoId}
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<ArchivoDelDispositivoEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(int id)
        {
            try
            {
                string query;

                query = $@"UPDATE archivo_del_dispositivo SET is_activo = 1 WHERE id = {id}";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query(query);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }//end class
}
