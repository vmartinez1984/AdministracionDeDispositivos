using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.BusinessLayer.Mapper
{
    public class DispositivoMapper
    {
        public static List<DispositivoItem> GetAll(List<DispositivoItemEntity> entities)
        {
            IMapper mapper;
            List<DispositivoItem> lista;

            mapper = GetMapperEntityToItem();
            lista = mapper.Map<List<DispositivoItem>>(entities);

            return lista;
        }

        public static DispositivoEntity Get(Dispositivo item)
        {
            IMapper mapper;
            DispositivoEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<DispositivoEntity>(item);

            return entity;
        }

        public static Dispositivo Get(DispositivoEntity entity)
        {
            IMapper mapper;
            Dispositivo item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<Dispositivo>(entity);

            return item;
        }

        private static IMapper GetMapperEntityToItem()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<DispositivoItemEntity, DispositivoItem>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<DispositivoEntity, Dispositivo>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static object GetNombreDelDispositivo(int tipoDeDispositivoId, List<TipoDeDispositivoEntity> tipoDeDispositivoEntities)
        {
            TipoDeDispositivoEntity entity;
            string nombre;

            entity = tipoDeDispositivoEntities.Where(x => x.Id == tipoDeDispositivoId).FirstOrDefault();
            if (entity == null)
                nombre = string.Empty;
            else
                nombre = entity.Nombre;

            return nombre;
        }

        private static string GetNombreDeLaAgencia(int agenciaId, List<AgenciaEntity> entities)
        {
            AgenciaEntity entity;
            string nombreDeLaAgencia;

            entity = entities.Where(x => x.Id == agenciaId).FirstOrDefault();
            if (entity == null)
                nombreDeLaAgencia = string.Empty;
            else
                nombreDeLaAgencia = $"{entity.Clave} {entity.Nombre}";

            return nombreDeLaAgencia;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<Dispositivo, DispositivoEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}
