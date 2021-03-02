using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
    public class AgenciaYDispositivosMapper
    {
        public static List<AgenciaYDispositivos> GetAll(List<AgenciaYDispositivoEntity> entities)
        {
            IMapper mapper;
            List<AgenciaYDispositivos> lista;

            mapper = GetMapperEntityToItem();
            lista = mapper.Map<List<AgenciaYDispositivos>>(entities);

            return lista;
        }

        private static IMapper GetMapperEntityToItem()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<AgenciaYDispositivoEntity, AgenciaYDispositivos>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}
