using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
    public class PerfilMapper
    {
        public static List<Perfil> GetAll(List<PerfilEntity> entities)
        {
            IMapper mapper;
            List<Perfil> lista;

            mapper = GetMapperEntityToDto();
            lista = mapper.Map<List<Perfil>>(entities);

            return lista;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<PerfilEntity, Perfil>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

    }//end class
}