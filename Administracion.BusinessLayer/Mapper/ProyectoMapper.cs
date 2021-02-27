using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
    public class ProyectoMapper
    {
        public static List<Proyecto> GetAll(List<ProyectoEntity> entities)
        {
            IMapper mapper;
            List<Proyecto> lista;

            mapper = GetMapperEntityToDto();
            lista = mapper.Map<List<Proyecto>>(entities);

            return lista;
        }

        public static ProyectoEntity Get(Proyecto item)
        {
            IMapper mapper;
            ProyectoEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<ProyectoEntity>(item);

            return entity;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<ProyectoEntity, Proyecto>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<Proyecto, ProyectoEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}
