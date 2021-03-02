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
    public class DispositivoBl
    {
        public static List<DispositivoItem> GetAll()
        {
            try
            {
                List<DispositivoItem> lista;

                lista = GetLista();

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<DispositivoItem> GetAll(DispositivoBusqueda item)
        {
            try
            {
                List<DispositivoItem> lista;

                lista = GetLista(item);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DispositivoDetalle GetDetalle(int id)
        {
            DispositivoDetalle item;
            DispositivoEntity entity;
            AgenciaEntity agenciaEntity;
            ProyectoEntity proyectoEntity;
            EstatusDelDispositivoEntity estatusDelDispositivoEntity;
            TipoDeDispositivoEntity tipoDeDispositivoEntity;

            entity = DispositivoDao.Get(id);
            agenciaEntity = AgenciaDao.Get(entity.AgenciaId);
            proyectoEntity = ProyectoDao.GetAll().Where(x => x.Id == agenciaEntity.ProyectoId).FirstOrDefault();
            estatusDelDispositivoEntity = EstatusDeDispositivoDao.Get(entity.EstatusDelDispositivoId);
            tipoDeDispositivoEntity = TipoDeDispositivoDao.Get(entity.TipoDeDispositivoId);
            item = new DispositivoDetalle
            {
                Id = entity.Id,
                Agencia = agenciaEntity.Nombre,
                Comentarios = agenciaEntity.Comentarios,
                FechaDeRegistro = entity.FechaDeRegistro,
                Proyecto = proyectoEntity.Nombre,
                EstatusDelDispositivo = estatusDelDispositivoEntity.Nombre,
                NumeroDeSerie = entity.NumeroDeSerie,
                TipoDeDispositivo = tipoDeDispositivoEntity.Nombre,
                ListaDeArchivos = ArchivoDeDispositivoBl.GetAll(entity.Id),
                ListaDeBitacora = GetListaDeBitacora(entity.Id)
            };

            return item;
        }

        private static List<DispositivoBitacora> GetListaDeBitacora(int dispositivoId)
        {
            DispositivoEntity entity;
            List<DispositivoBitacora> lista;

            entity = DispositivoDao.Get(dispositivoId);
            if (string.IsNullOrEmpty(entity.Bitacora))
            {
                lista = new List<DispositivoBitacora>();
            }
            else
            {
                lista = JsonConvert.DeserializeObject<List<DispositivoBitacora>>(entity.Bitacora);
            }

            return lista;
        }

        private static List<DispositivoItem> GetLista(DispositivoBusqueda item)
        {
            List<DispositivoItem> lista;
            List<DispositivoItemEntity> entities;

            entities = DispositivoDao.GetAll(item.TipoDeDispositivoId, item.EstatusDelDispositivoId, item.ProyectoId, item.AgenciaId, item.NumeroDeSerie);
            lista = DispositivoMapper.GetAll(entities);

            return lista;
        }

        private static List<DispositivoItem> GetLista()
        {
            List<DispositivoItem> lista;
            List<DispositivoItemEntity> entities;

            entities = DispositivoDao.GetAll();
            lista = DispositivoMapper.GetAll(entities);

            return lista;
        }

        public static Dispositivo Get(int id)
        {
            Dispositivo item;
            DispositivoEntity entity;
            AgenciaEntity agenciaEntity;

            entity = DispositivoDao.Get(id);
            item = DispositivoMapper.Get(entity);
            agenciaEntity = AgenciaDao.Get(entity.AgenciaId);
            item.AgenciaId = agenciaEntity.Id;
            item.ProyectoId = agenciaEntity.ProyectoId;
            item.ListaDeArchivos = ArchivoDeDispositivoBl.GetAll(entity.Id);

            return item;
        }

        public static int Add(Dispositivo item)
        {
            try
            {
                DispositivoEntity entity;

                entity = DispositivoMapper.Get(item);
                item.Id = DispositivoDao.Add(entity);

                return item.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(Dispositivo item)
        {
            try
            {
                DispositivoEntity entity;

                entity = DispositivoMapper.Get(item);
                entity.Bitacora = GetBitacora(item.Id);
                foreach (var archivoDeDispositivo in item.ListaDeArchivos)
                {
                    if (archivoDeDispositivo.IsActivo == false)
                        ArchivoDelDispositivoDao.Delete(archivoDeDispositivo.Id);
                }

                DispositivoDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string GetBitacora(int dispositivoId)
        {
            DispositivoEntity entity;
            string bitacora;
            List<DispositivoBitacora> lista;
            DispositivoBitacora dispositivoBitacora;

            entity = DispositivoDao.Get(dispositivoId);
            if (string.IsNullOrEmpty(entity.Bitacora))
            {
                lista = new List<DispositivoBitacora>();
            }
            else
            {
                lista = JsonConvert.DeserializeObject<List<DispositivoBitacora>>(entity.Bitacora);
            }
            dispositivoBitacora = GetDispositivoBitacora(entity);
            lista.Add(dispositivoBitacora);
            bitacora = JsonConvert.SerializeObject(lista);

            return bitacora;
        }

        private static DispositivoBitacora GetDispositivoBitacora(DispositivoEntity entity)
        {
            AgenciaEntity agenciaEntity;
            ProyectoEntity proyectoEntity;
            TipoDeDispositivoEntity tipoDeDispositivoEntity;
            EstatusDelDispositivoEntity estatusDelDispositivoEntity;
            UsuarioEntity usuarioEntity;
            DispositivoBitacora dispositivoBitacora;

            agenciaEntity = AgenciaDao.Get(entity.AgenciaId);
            proyectoEntity = ProyectoDao.GetAll().Where(x => x.Id == agenciaEntity.ProyectoId).FirstOrDefault();
            tipoDeDispositivoEntity = TipoDeDispositivoDao.Get(entity.TipoDeDispositivoId);
            estatusDelDispositivoEntity = EstatusDeDispositivoDao.Get(entity.EstatusDelDispositivoId);
            usuarioEntity = UsuarioDao.Get(entity.UsuarioId);
            dispositivoBitacora = new DispositivoBitacora
            {
                AgenciaNombre = agenciaEntity.Nombre,
                Comentarios = entity.Comentarios,
                NumeroDeSerie = entity.NumeroDeSerie,
                ProtectoNombre = proyectoEntity.Nombre,
                TipoDeDispositivoNombre = tipoDeDispositivoEntity.Nombre,
                EstatusDelDispositivo = estatusDelDispositivoEntity.Nombre,
                Usuario = usuarioEntity.Nombre
            };

            return dispositivoBitacora;
        }
    }
}