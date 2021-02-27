using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class EstatusDeDispositivoDao
    {
        public static List<EstatusDelDispositivoEntity> GetAll()
        {
            try
            {
                List<EstatusDelDispositivoEntity> entities;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM estatus_del_dispositivo
                WHERE is_activo = 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<EstatusDelDispositivoEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(EstatusDelDispositivoEntity entity)
        {
            try
            {
                string query;

                query = $@"
                INSERT INTO estatus_del_dispositivo
                (
                    nombre,
                    is_activo
                )
                VALUES
                (
                    @Nombre,
                    1
                )                
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query,new
                    {
                        Nombre = entity.Nombre
                    }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static EstatusDelDispositivoEntity Get(int id)
        {
            try
            {
                EstatusDelDispositivoEntity entities;
                string query;

                query = $@"
                SELECT 
                    {Campos.Catalogo}
                FROM estatus_del_dispositivo
                WHERE is_activo = 1
                AND id = {id}
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<EstatusDelDispositivoEntity>(query).FirstOrDefault();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(EstatusDelDispositivoEntity entity)
        {
            try
            {
                string query;

                query = $@"UPDATE estatus_del_dispositivo SET nombre = @Nombre WHERE id = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query<int>(query, new { Nombre = entity.Nombre, Id = entity.Id });
                }

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

                query = $@"UPDATE estatus_del_dispositivo SET is_activo = 0  WHERE id = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query<int>(query, new { Id = id });
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

    }//end class
}