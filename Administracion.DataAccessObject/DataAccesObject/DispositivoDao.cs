using Administracion.DataAccessObject.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.DataAccessObject.DataAccesObject
{
    public class DispositivoDao
    {
        public static List<DispositivoItemEntity> GetAll()
        {
            try
            {
                List<DispositivoItemEntity> entities;
                string query;

                query = $@"
                SELECT 
                    dispositivo.id,
                    tipo_de_dispositivo.nombre      TipoDeDispositivoNombre,
                    agencia.clave                   AgenciaClave,
                    agencia.nombre                  AgenciaNombre,
                    dispositivo.numero_de_serie     NumeroDeSerie,
                    dispositivo.comentarios,
                    estatus_del_dispositivo.nombre  EstatusDelDispositivoNombre
                    FROM dispositivo
                INNER JOIN tipo_de_dispositivo ON dispositivo.tipo_de_dispositivo_id = tipo_de_dispositivo.id
                INNER JOIN agencia ON dispositivo.agencia_id = agencia.id
                INNER JOIN estatus_del_dispositivo ON dispositivo.estatus_del_dispositivo_id = estatus_del_dispositivo.id
                ORDER BY dispositivo.id DESC
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<DispositivoItemEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<DispositivoItemEntity> GetAllByProyecto(int proyectoId)
        {
            try
            {
                List<DispositivoItemEntity> entities;
                string query;

                query = $@"
                SELECT 
                    dispositivo.id,
                    tipo_de_dispositivo.nombre      TipoDeDispositivoNombre,
                    agencia.clave                   AgenciaClave,
                    agencia.nombre                  AgenciaNombre,
                    dispositivo.numero_de_serie     NumeroDeSerie,
                    dispositivo.comentarios,
                    estatus_del_dispositivo.nombre  EstatusDelDispositivoNombre
                    FROM dispositivo
                INNER JOIN tipo_de_dispositivo ON dispositivo.tipo_de_dispositivo_id = tipo_de_dispositivo.id
                INNER JOIN agencia ON dispositivo.agencia_id = agencia.id
                INNER JOIN estatus_del_dispositivo ON dispositivo.estatus_del_dispositivo_id = estatus_del_dispositivo.id
                WHERE agencia.proyecto_id = {proyectoId}
                ORDER BY dispositivo.id DESC
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<DispositivoItemEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<DispositivoItemEntity> GetAll(int? tipoDeDispositivoId, int? estatusDelDispositivoId, int? proyectoId, int? agenciaId, string numeroDeSerie)
        {
            try
            {
                List<DispositivoItemEntity> entities;
                string query;

                query = $@"
                 SELECT 
                    dispositivo.id,
                    tipo_de_dispositivo.nombre      TipoDeDispositivoNombre,
                    agencia.clave                   AgenciaClave,
                    agencia.nombre                  AgenciaNombre,
                    dispositivo.numero_de_serie     NumeroDeSerie,
                    dispositivo.comentarios,
                    estatus_del_dispositivo.nombre  EstatusDelDispositivoNombre
                    FROM dispositivo
                INNER JOIN tipo_de_dispositivo ON dispositivo.tipo_de_dispositivo_id = tipo_de_dispositivo.id
                INNER JOIN agencia ON dispositivo.agencia_id = agencia.id
                INNER JOIN estatus_del_dispositivo ON dispositivo.estatus_del_dispositivo_id = estatus_del_dispositivo.id
                ";
                if (tipoDeDispositivoId != null)
                {
                    query += $" WHERE tipo_de_dispositivo_id = {tipoDeDispositivoId} ";
                }
                if (estatusDelDispositivoId != null)
                {
                    if (query.Contains("WHERE"))
                        query += $" AND estatus_del_dispositivo.id = {estatusDelDispositivoId} ";
                    else
                        query += $" WHERE estatus_del_dispositivo.id = {estatusDelDispositivoId} ";
                }
                if (proyectoId != null)
                {
                    if (query.Contains("WHERE"))
                        query += $" AND agencia.proyecto_id = {proyectoId} ";
                    else
                        query += $" WHERE agencia.proyecto_id = {proyectoId} ";
                }
                if (agenciaId != null)
                {
                    if (query.Contains("WHERE"))
                        query += $" AND agencia.id = {agenciaId} ";
                    else
                        query += $" WHERE agencia.id = {agenciaId} ";
                }
                if (!string.IsNullOrEmpty(numeroDeSerie))
                {
                    if (query.Contains("WHERE"))
                        query += $" AND numero_de_serie like '%{numeroDeSerie}%' ";
                    else
                        query += $" WHERE numero_de_serie like '%{numeroDeSerie}%' ";
                }
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<DispositivoItemEntity>(query).ToList();
                }

                return entities;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DispositivoEntity Get(int id)
        {
            try
            {
                DispositivoEntity entity;
                string query;

                query = $@"
                SELECT 
                    id,
                    agencia_id                  AgenciaId,
                    estatus_del_dispositivo_id  EstatusDelDispositivoId,
                    fecha_de_registro           FechaDeRegistro,
                    is_activo IsActivo,
                    {Campos.FechaDeBaja},
                    tipo_de_dispositivo_id      TipoDeDispositivoId,
                    numero_de_serie             NumeroDeSerie,
                    comentarios,
                    bitacora,              
                    fecha_de_edicion            FechaDeEdicion,
                    usuario_id                  UsuarioId
                FROM dispositivo
                WHERE id = {id}
                LIMIT 1
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<DispositivoEntity>(query).FirstOrDefault();
                }

                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(DispositivoEntity entity)
        {
            try
            {
                string query;

                query = $@"
                INSERT INTO dispositivo 
                (
                    agencia_id,
                    tipo_de_dispositivo_id,
                    numero_de_serie,
                    comentarios,
                    is_activo,
                    fecha_de_registro,
                    estatus_del_dispositivo_id,
                    usuario_id
                ) 
                VALUES 
                (
                    @AgenciaId,
                    @TipoDeDispositivoId,
                    @NumeroDeSerie,
                    @Comentarios,
                    1,
                    NOW(),
                    @EstatusDelDispositivoId,
                    @UsuarioId
                ); SELECT LAST_INSERT_ID();";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new
                    {
                        AgenciaId = entity.AgenciaId,
                        TipoDeDispositivoId = entity.TipoDeDispositivoId,
                        NumeroDeSerie = entity.NumeroDeSerie,
                        Comentarios = entity.Comentarios,
                        EstatusDelDispositivoId = entity.EstatusDelDispositivoId,
                        UsuarioId = entity.UsuarioId
                    }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(DispositivoEntity entity)
        {
            try
            {
                string query;

                query = $@"
                UPDATE dispositivo 
                SET 
                    agencia_id                  = @AgenciaId,
                    tipo_de_dispositivo_id      = @TipoDeDispositivoId,
                    usuario_id                  = @UsuarioId,
                    estatus_del_dispositivo_id  = @EstatusDelDispositivoId,
                    numero_de_serie             = @NumeroDeSerie,
                    comentarios                 = @Comentarios,
                    bitacora                    = @Bitacora,
                    fecha_de_edicion            = NOW()
                WHERE id = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {                    
                    db.Query(query, new
                    {
                        AgenciaId = entity.AgenciaId,
                        TipoDeDispositivoId = entity.TipoDeDispositivoId,
                        UsuarioId = entity.UsuarioId,
                        EstatusDelDispositivoId = entity.EstatusDelDispositivoId,
                        NumeroDeSerie = entity.NumeroDeSerie,
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

                query = $@"UPDATE Dispositivo 
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
    }//end class
}
