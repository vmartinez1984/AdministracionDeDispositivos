using Administracion.BusinessLayer.Dto;
using Administracion.BusinessLayer.Mapper;
using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.BusinessLayer.Bl
{
    public class AgenciaBl
    {
        public static List<AgenciaItem> GetAll()
        {
            try
            {
                List<AgenciaItem> lista;
                List<AgenciaItemEntity> entities;

                entities = AgenciaDao.GetAll();
                lista = AgenciaMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<AgenciaItem> GetAll(int proyectoId)
        {
            try
            {
                List<AgenciaItem> lista;
                List<AgenciaItemEntity> entities;

                entities = AgenciaDao.GetAll(proyectoId);
                lista = AgenciaMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(Agencia item)
        {
            try
            {
                AgenciaEntity entity;

                entity = AgenciaMapper.Get(item);
                entity.Id = AgenciaDao.Add(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static AgenciaDetalle GetDetalle(int agenciaId)
        {
            try
            {
                AgenciaDetalle item;
                AgenciaDetailsEntity entity;
                List<AgenciaBitacora> lista;

                entity = AgenciaDao.GetDetalle(agenciaId);
                lista = CargarBitacora(entity.Bitacora);
                item = AgenciaMapper.GetAgenciaDetalle(entity);
                item.ListaDeBitacora = lista;

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<AgenciaBitacora> CargarBitacora(string bitacora)
        {
            List<AgenciaBitacora> lista;

            lista = new List<AgenciaBitacora>();
            if (!string.IsNullOrEmpty(bitacora))
            {
                List<AgenciaEntity> entities;
                List<EstadoEntity> estadoEntities;
                List<ProyectoEntity> proyectoEntities;
                List<TipoDeAgenciaEntity> tipoDeAgenciaEntities;
                List<UsuarioEntity> usuarioEntities;

                estadoEntities = EstadoDao.GetAll();
                proyectoEntities = ProyectoDao.GetAll();
                tipoDeAgenciaEntities = TipoDeAgenciaDao.GetAll();
                usuarioEntities = UsuarioDao.GetAll();
                entities = JsonConvert.DeserializeObject<List<AgenciaEntity>>(bitacora);
                foreach (var entity in entities)
                {
                    lista.Add(new AgenciaBitacora
                    {
                        Ciudad = entity.Ciudad,
                        Clave = entity.Clave,
                        Comentarios = entity.Comentarios,
                        Estado = GetEstado(entity.EstadoId, estadoEntities),
                        Nombre = entity.Nombre,
                        FechaDeBaja = entity.FechaDeBaja,
                        FechaDeEdicion = entity.FechaDeEdicion,
                        FechaDeRegistro = entity.FechaDeRegistro,
                        ProyectoNombre = Getprotecto(entity.ProyectoId, proyectoEntities),
                        TipoDeAgencia = GetTipoDeAgencia(entity.TipoDeAgenciaId, tipoDeAgenciaEntities),
                        Usuario = GetUsuario(entity.UsuarioId, usuarioEntities)
                    });
                }
            }

            return lista;
        }

        private static string GetUsuario(int usuarioId, List<UsuarioEntity> entities)
        {
            string nombre;

            nombre = entities.Where(x => x.Id == usuarioId).FirstOrDefault().Nombre;

            return nombre;
        }

        private static string GetTipoDeAgencia(int tipoDeAgenciaId, List<TipoDeAgenciaEntity> entities)
        {
            string nombre;

            nombre = entities.Where(x => x.Id == tipoDeAgenciaId).FirstOrDefault().Nombre;

            return nombre;
        }

        private static string Getprotecto(int proyectoId, List<ProyectoEntity> entities)
        {
            string nombre;

            nombre = entities.Where(x => x.Id == proyectoId).FirstOrDefault().Nombre;

            return nombre;
        }

        private static string GetEstado(int? estadoId, List<EstadoEntity> entities)
        {
            string nombre;

            if (estadoId == null || estadoId == 0)
            {
                nombre = string.Empty;
            }
            else
            {
                nombre = entities.Where(x => x.Id == estadoId).FirstOrDefault().Nombre;
            }

            return nombre;
        }

        public static Agencia Get(int id)
        {
            try
            {
                Agencia item;
                AgenciaEntity entity;

                entity = AgenciaDao.Get(id);
                item = AgenciaMapper.Get(entity);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(Agencia item)
        {
            try
            {
                AgenciaEntity entity;


                entity = AgenciaMapper.Get(item);
                entity.Bitacora = GetBitacora(item.Id);

                AgenciaDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string GetBitacora(int id)
        {
            string bitacora;
            AgenciaEntity entity;
            List<AgenciaEntity> entities;

            entity = AgenciaDao.Get(id);
            if (string.IsNullOrEmpty(entity.Bitacora))
            {

                entities = new List<AgenciaEntity>();
                entities.Add(entity);
            }
            else
            {
                entities = JsonConvert.DeserializeObject<List<AgenciaEntity>>(entity.Bitacora);
                entity.Bitacora = string.Empty;
                entities.Add(entity);
            }
            bitacora = JsonConvert.SerializeObject(entities);

            return bitacora;
        }

        public static void Delete(int id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static dynamic GetAllAgenciaItem(int protectoId)
        {
            try
            {
                List<AgenciaItem> lista;
                List<AgenciaItemEntity> entities;

                entities = AgenciaDao.GetAll(protectoId);
                lista = AgenciaMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }//en class
}