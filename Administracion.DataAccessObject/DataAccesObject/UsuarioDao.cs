using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class UsuarioDao
    {
        public static List<UsuarioEntity> GetAll()
        {
            try
            {
                List<UsuarioEntity> entities;
                string query;

                query = $@"
                SELECT
                    usuario.id,
                    perfil_id          PerfilId,
                    perfil.nombre		PerfilNombre,
                    usuario.nombre,
                    contrasenia,
                    fecha_de_registro  FechaDeRegistro,
                    is_activo				IsActivo
                FROM   usuario
                INNER JOIN perfil ON usuario.perfil_id = perfil.id     
                WHERE is_activo = 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<UsuarioEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<UsuarioEntity> GetAllEliminados()
        {
            try
            {
                List<UsuarioEntity> entities;
                string query;

                query = $@"
                SELECT
                    usuario.id,
                    perfil_id          PerfilId,
                    perfil.nombre		PerfilNombre,
                    usuario.nombre,
                    contrasenia,
                    fecha_de_registro  FechaDeRegistro,
                    is_activo				IsActivo
                FROM   usuario
                INNER JOIN perfil ON usuario.perfil_id = perfil.id     
                WHERE is_activo = 0
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<UsuarioEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static UsuarioEntity Get(string nombre, string contrasenia)
        {
            try
            {
                UsuarioEntity entity;
                string query;

                query = $@"
                SELECT
                    id,
                    perfil_id,
                    nombre,
                    contrasenia,
                    fecha_de_registro
                FROM   usuario   
                WHERE nombre_de_usuario = @Nombre AND contrasenia = @Contrasenia
                LIMIT 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<UsuarioEntity>(query, new
                    {
                        Nombre = nombre,
                        Contrasenia = contrasenia
                    }).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(int usuarioId)
        {
            try
            {
                string query;

                query = $@"
                UPDATE usuario
                SET
                    is_activo   = 0,
                    fecha_de_baja = NOW()
                WHERE id = {usuarioId};
                ";
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

        public static UsuarioEntity Get(int usuarioId)
        {
            try
            {
                UsuarioEntity entity;
                string query;

                query = $@"
                SELECT
                    id,
                    perfil_id           PerfilId,
                    nombre,
                    nombre_de_usuario   NombreDeUsuario,
                    contrasenia,
                    fecha_de_registro   FechaDeRegistro,
                    is_activo           IsActivo
                FROM   usuario   
                WHERE id = {usuarioId}
                LIMIT 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<UsuarioEntity>(query).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(UsuarioEntity entity)
        {
            try
            {
                string query;

                query = $@"
                INSERT INTO usuario
                (
                    perfil_id,
                    nombre,
                    nombre_de_usuario,
                    contrasenia,
                    fecha_de_registro,
                    is_activo
                )
                VALUES
                (
                    @PerfilId,
                    @Nombre,
                    @NombreDeUsuario,
                    @Contrasenia,
                    NOW(),
                    1
                );          
                SELECT LAST_INSERT_ID();
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<UsuarioEntity>(query, new
                    {
                        PerfilId = entity.PerfilId,
                        Nombre = entity.Nombre,
                        NombreDeUsuario = entity.NombreDeUsuario,
                        Contrasenia = entity.Contrasenia
                    }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(UsuarioEntity entity)
        {
            try
            {
                string query;

                query = $@"
                UPDATE usuario
                SET
                    contrasenia         = @Contrasenia,
                    perfil_id           = @PerfilId,
                    nombre              = @Nombre,  
                    nombre_de_usuario   = @NombreDeUsuario
                WHERE id = @Id;
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query(query, new
                    {
                        Contrasenia = entity.Contrasenia,
                        PerfilId = entity.PerfilId,
                        Nombre = entity.Nombre,
                        NombreDeUsuario = entity.NombreDeUsuario,
                        Id = entity.Id
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}