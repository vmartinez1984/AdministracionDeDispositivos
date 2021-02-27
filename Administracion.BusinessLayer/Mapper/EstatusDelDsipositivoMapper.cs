using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
   public class EstatusDelDsipositivoMapper
    {
        public static List<EstatusDelDispositivo> GetAll(List<EstatusDelDispositivoEntity> entities)
        {
            IMapper mapper;
            List<EstatusDelDispositivo> lista;

            mapper = GetMapperEntityToDto();
            lista = mapper.Map<List<EstatusDelDispositivo>>(entities);

            return lista;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<EstatusDelDispositivoEntity, EstatusDelDispositivo>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<EstatusDelDispositivo, EstatusDelDispositivoEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static EstatusDelDispositivoEntity Get(EstatusDelDispositivo item)
        {
            IMapper mapper;
            EstatusDelDispositivoEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<EstatusDelDispositivoEntity>(item);

            return entity;
        }

        internal static EstatusDelDispositivo Get(EstatusDelDispositivoEntity entity)
        {
            IMapper mapper;
            EstatusDelDispositivo item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<EstatusDelDispositivo>(entity);

            return item;
        }
    }
}
