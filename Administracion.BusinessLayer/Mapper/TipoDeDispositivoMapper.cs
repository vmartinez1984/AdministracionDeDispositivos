using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
    public class TipoDeDispositivoMapper
    {
        public static List<TipoDeDispositivo> GetAll(List<TipoDeDispositivoEntity> entities)
        {
            IMapper mapper;
            List<TipoDeDispositivo> lista;

            mapper = GetMapperEntityToDto();
            lista = mapper.Map<List<TipoDeDispositivo>>(entities);

            return lista;
        }

        public static TipoDeDispositivoEntity Get(TipoDeDispositivo item)
        {
            IMapper mapper;
            TipoDeDispositivoEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<TipoDeDispositivoEntity>(item);

            return entity;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<TipoDeDispositivoEntity, TipoDeDispositivo>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<TipoDeDispositivo, TipoDeDispositivoEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static TipoDeDispositivo Get(TipoDeDispositivoEntity entity)
        {
            IMapper mapper;
            TipoDeDispositivo item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<TipoDeDispositivo>(entity);

            return item;

        }
    }
}
