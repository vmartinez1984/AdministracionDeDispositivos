using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
    public class EstadoMapper
    {
        public static List<Estado> GetAll(List<EstadoEntity> entities)
        {
            IMapper mapper;
            List<Estado> lista;

            mapper = GetMapperEntityToDto();
            lista = mapper.Map<List<Estado>>(entities);

            return lista;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<EstadoEntity, Estado>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}