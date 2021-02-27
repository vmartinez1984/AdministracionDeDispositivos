using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class AgenciaDao
    {
        public static List<AgenciaItemEntity> GetAll()
        {
            try
            {
                List<AgenciaItemEntity> entities;
                string query;

                query = $@"
                SELECT 
                    agencia.id,
                    proyecto.nombre			    ProyectoNombre,
                    agencia.clave,
                    agencia.nombre,
                    tipo_de_agencia.nombre      TipoDeAgencia,
                    agencia.ciudad,
                    estado.nombre				Estado,
                    agencia.comentarios         Comentarios
                FROM agencia
                INNER JOIN proyecto ON agencia.proyecto_id = proyecto.id
                INNER JOIN tipo_de_agencia ON  agencia.tipo_de_agencia_id = tipo_de_agencia.id
                LEFT JOIN estado ON agencia.estado_id = estado.id
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<AgenciaItemEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<AgenciaItemEntity> GetAll(int proyectoId)
        {
            try
            {
                List<AgenciaItemEntity> entities;
                string query;

                query = $@"
                SELECT 
                    agencia.id,
                    proyecto.nombre			ProyectoNombre,
                    agencia.clave,
                    agencia.nombre,
                    tipo_de_agencia.nombre TipoDeAgencia,
                    agencia.ciudad,
                    estado.nombre				Estado,
                    agencia.comentarios
                FROM agencia
                INNER JOIN proyecto ON agencia.proyecto_id = proyecto.id
                INNER JOIN tipo_de_agencia ON  agencia.tipo_de_agencia_id = tipo_de_agencia.id
                LEFT JOIN estado ON agencia.estado_id = estado.nombre
                WHERE agencia.proyecto_id = {proyectoId}
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<AgenciaItemEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static AgenciaEntity Get(int id)
        {
            try
            {
                AgenciaEntity entity;
                string query;

                query = $@"
                SELECT 
	                id,
	                proyecto_id				ProyectoId,
	                tipo_de_agencia_id	TipoDeAgenciaId,
	                estado_id				EstadoId,
	                usuario_id				UsuarioId,
	                clave,
	                nombre,
	                ciudad,
	                comentarios,
	                is_activo,
	                fecha_de_registro		FechaDeRegistro,
	                fecha_de_edicion		FechaDeEdicion,
	                fecha_de_baja			FechaDeBaja,
	                bitacora	
                FROM agencia
                WHERE id = {id}
                LIMIT 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<AgenciaEntity>(query).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(AgenciaEntity entity)
        {
            try
            {
                string query;

                query = $@"
                INSERT INTO agencia 
                (
                    proyecto_id,
                    tipo_de_agencia_id,
                    estado_id,
                    usuario_id,
                    clave,
                    nombre,
                    ciudad,
                    comentarios,
                    is_activo,
                    fecha_de_registro
                ) 
                VALUES 
                (
                    @ProyectoId,
                    @TipoDeAgenciaId,
                    @EstadoId,
                    @UsuarioId,
                    @Clave,
                    @Nombre,
                    @Ciudad,
                    @Comentarios,
                    1,
                    NOW()
                ); SELECT LAST_INSERT_ID();";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new
                    {
                        ProyectoId = entity.ProyectoId,
                        TipoDeAgenciaId = entity.TipoDeAgenciaId,
                        EstadoId = entity.EstadoId,
                        UsuarioId = entity.UsuarioId,
                        Clave = entity.Clave,
                        Nombre = entity.Nombre,
                        Ciudad = entity.Ciudad,
                        Comentarios = entity.Comentarios
                    }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static AgenciaDetailsEntity GetDetalle(int agenciaId)
        {
            try
            {
                AgenciaDetailsEntity entity;
                string query;

                query = $@"
                 SELECT 
                    agencia.id,
                    proyecto.nombre					ProyectoNombre,
                    agencia.clave,
                    agencia.nombre,
                    tipo_de_agencia.nombre 		    TipoDeAgencia,
                    agencia.ciudad,
                    estado.nombre					Estado,
                    agencia.comentarios,
                    agencia.fecha_de_registro 	    FechaDeRegistro,
                    agencia.fecha_de_edicion		FechaDeEdicion,
					agencia.fecha_de_baja			FechaDeBaja,
					agencia.bitacora,
					usuario.nombre					Usuario
                FROM agencia
                INNER JOIN proyecto ON agencia.proyecto_id = proyecto.id
                INNER JOIN tipo_de_agencia ON  agencia.tipo_de_agencia_id = tipo_de_agencia.id
                LEFT  JOIN estado ON agencia.estado_id = estado.id
                LEFT	 JOIN usuario ON agencia.usuario_id = usuario.id
                WHERE agencia.id = {agenciaId}
                LIMIT 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<AgenciaDetailsEntity>(query).FirstOrDefault();
                }

                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(AgenciaEntity entity)
        {
            try
            {
                string query;

                query = $@"
                UPDATE agencia 
                SET 
	                proyecto_id			    = @ProyectoId,
	                tipo_de_agencia_id	    = @TipoDeAgenciaId,
	                estado_id				= @EstadoId,
	                usuario_id				= @UsuarioId,
	                clave                   = @Clave,
	                nombre                  = @Nombre,
	                ciudad                  = @Ciudad,
	                comentarios             = @Comentarios,	                
	                fecha_de_edicion		= NOW(),
	                bitacora	            = @Bitacora
                WHERE id = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query(query, new
                    {
                        ProyectoId = entity.ProyectoId,
                        TipoDeAgenciaId = entity.TipoDeAgenciaId,
                        EstadoId = entity.EstadoId,
                        UsuarioId = entity.UsuarioId,
                        Clave = entity.Clave,
                        Nombre = entity.Nombre,
                        Ciudad = entity.Ciudad,
                        Comentarios = entity.Comentarios,
                        Bitacora = entity.Bitacora,
                        Id = entity.Id
                    });
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

                query = $@"UPDATE agencia 
                SET 
                    is_activo = 0,
                    fecha_de_baja = NOW();    
                WHERE id = @Id";
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
    }
}
