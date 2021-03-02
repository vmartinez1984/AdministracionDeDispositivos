using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
public     class TotalDeDispositivosMapper
    {
        public static List<TotalDeDispositivos> GetAll(List<TotalDeDispositivosEntity> entities)
        {
            IMapper mapper;
            List<TotalDeDispositivos> lista;

            mapper = GetMapperEntityToDto();
            lista = mapper.Map<List<TotalDeDispositivos>>(entities);

            return lista;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<TotalDeDispositivosEntity, TotalDeDispositivos>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}
