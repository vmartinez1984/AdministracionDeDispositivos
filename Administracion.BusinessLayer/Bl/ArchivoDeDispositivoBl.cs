using Administracion.DataAccessObject.Entities;
using Administracion.DataAccessObject.DataAccesObject;
using System;
using System.Collections.Generic;
using Administracion.BusinessLayer.Dto;
using System.IO;

namespace Administracion.BusinessLayer.Bl
{
    public class ArchivoDeDispositivoBl
    {
        public static void Add(string rutaDelArchivo, int dispositivoId)
        {
            try
            {
                ArchivoDelDispositivoEntity entity;

                entity = new ArchivoDelDispositivoEntity
                {
                    DispositivoId = dispositivoId,
                    RutaDelArchivo = rutaDelArchivo
                };
                ArchivoDelDispositivoDao.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ArchivoDeDispositivo> GetAll(int dispositivoId)
        {
            try
            {
                List<ArchivoDelDispositivoEntity> entities;
                List<ArchivoDeDispositivo> lista;

                entities = ArchivoDelDispositivoDao.GetAll(dispositivoId);
                lista = GetLista(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<ArchivoDeDispositivo> GetLista(List<ArchivoDelDispositivoEntity> entities)
        {
            List<ArchivoDeDispositivo> lista;

            lista = new List<ArchivoDeDispositivo>();
            foreach (var entity in entities)
            {
                ArchivoDeDispositivo item;

                item = GetItem(entity);
                lista.Add(item);
            }

            return lista;
        }

        private static ArchivoDeDispositivo GetItem(ArchivoDelDispositivoEntity entity)
        {
            ArchivoDeDispositivo item;

            item = new ArchivoDeDispositivo
            {
                Id = entity.Id,
                FechaDeRegistro = entity.FechaDeRegistro,
                Base64 = GetBase64(entity.RutaDelArchivo),
                TipoDeArchivo = GetTipoDeArchivo(entity.RutaDelArchivo)
            };

            return item;
        }

        private static string GetTipoDeArchivo(string rutaDelArchivo)
        {
            string tipoDeArchivo;
            string[] piezas;

            piezas = rutaDelArchivo.Split('.');
            tipoDeArchivo = piezas[1];

            return tipoDeArchivo;
        }

        private static string GetBase64(string rutaDelArchivo)
        {
            byte[] bytes;
            string base64;

            bytes = File.ReadAllBytes(rutaDelArchivo);
            base64 = Convert.ToBase64String(bytes);

            return base64;
        }
    }
}