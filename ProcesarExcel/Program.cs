using Administracion.DataAccessObject.DataAccesObject;
using Administracion.DataAccessObject.Entities;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesarExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutaDelArchivo;
            int row;
            SLDocument sLDocument;

            row = 2;
            rutaDelArchivo = @"C:\Users\vmartinez\Downloads\Numeros de serie AT9000 y CSD .xlsx";
            sLDocument = new SLDocument(rutaDelArchivo);

            while (!string.IsNullOrEmpty(sLDocument.GetCellValueAsString(row, 1)))
            {
                string claveDeLaAgencia;
                string nombreDeLaAgencia;
                string tipo;
                string ciudad;
                string numeroDeSerieDeAt9000;
                string numeroDeSerieDecsd200;
                AgenciaEntity entity;

                claveDeLaAgencia = sLDocument.GetCellValueAsString(row, 1);
                nombreDeLaAgencia = sLDocument.GetCellValueAsString(row, 2);
                tipo = sLDocument.GetCellValueAsString(row, 3);
                ciudad = sLDocument.GetCellValueAsString(row, 4);
                numeroDeSerieDeAt9000 = sLDocument.GetCellValueAsString(row, 5);
                numeroDeSerieDecsd200 = sLDocument.GetCellValueAsString(row, 6);
                entity = new AgenciaEntity
                {
                    Ciudad = ciudad,
                    Clave = claveDeLaAgencia,
                    Nombre = nombreDeLaAgencia,
                    TipoDeAgenciaId = GetTipoDeAgenciaId(tipo),
                    ProyectoId = 3,
                    UsuarioId = 1
                };
                entity.Id = AgenciaDao.Add(entity);
                AddAT90000(entity.Id, numeroDeSerieDeAt9000);
                AddCs200(entity.Id, numeroDeSerieDecsd200);
                Console.WriteLine($"{row} {entity.Clave} {numeroDeSerieDeAt9000} {numeroDeSerieDecsd200}");
                row++;
            }
            Console.ReadLine();
        }

        private static void AddAT90000(int agenciaId, string numeroDeSerieDeAt9000)
        {
            DispositivoEntity entity;

            entity = new DispositivoEntity
            {
                AgenciaId = agenciaId,
                NumeroDeSerie = numeroDeSerieDeAt9000,
                TipoDeDispositivoId = 1,
                EstatusDelDispositivoId = 2,
                UsuarioId = 1
            };
            DispositivoDao.Add(entity);
        }

        private static void AddCs200(int agenciaId, string numeroDeSerieDeAt9000)
        {
            DispositivoEntity entity;

            entity = new DispositivoEntity
            {
                AgenciaId = agenciaId,
                NumeroDeSerie = numeroDeSerieDeAt9000,
                TipoDeDispositivoId = 2,
                EstatusDelDispositivoId = 2,
                UsuarioId = 1
            };
            DispositivoDao.Add(entity);
        }

        private static int GetTipoDeAgenciaId(string tipo)
        {
            List<TipoDeAgenciaEntity> entities;
            TipoDeAgenciaEntity entity;
            int tipoDeAgenciaId;

            entities = TipoDeAgenciaDao.GetAll();
            entity = entities.Where(x => x.Nombre.ToUpper().Contains(tipo.ToUpper())).FirstOrDefault();
            if (entity != null)
            {
                tipoDeAgenciaId = entity.Id;
            }
            else
            {
                tipoDeAgenciaId = 0;
            }

            return tipoDeAgenciaId;
        }
    }
}
