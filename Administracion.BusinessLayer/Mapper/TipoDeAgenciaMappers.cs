using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
    public class TipoDeAgenciaMappers
    {
        public static List<TipoDeAgencia> GetAll(List<TipoDeAgenciaEntity> entities)
        {
            IMapper mapper;
            List<TipoDeAgencia> lista;

            mapper = GetMapperEntityToDto();
            lista = mapper.Map<List<TipoDeAgencia>>(entities);

            return lista;
        }

        public static TipoDeAgenciaEntity Get(TipoDeAgencia item)
        {
            IMapper mapper;
            TipoDeAgenciaEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<TipoDeAgenciaEntity>(item);

            return entity;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<TipoDeAgenciaEntity, TipoDeAgencia>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<TipoDeAgencia, TipoDeAgenciaEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static TipoDeAgencia Get(TipoDeAgenciaEntity entity)
        {
            IMapper mapper;
            TipoDeAgencia item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<TipoDeAgencia>(entity);

            return item;
        }
    }//end class
}