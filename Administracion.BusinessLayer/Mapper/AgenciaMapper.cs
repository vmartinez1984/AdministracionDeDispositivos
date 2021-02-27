using Administracion.BusinessLayer.Dto;
using Administracion.DataAccessObject.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Administracion.BusinessLayer.Mapper
{
    public class AgenciaMapper
    {
        public static List<AgenciaItem> GetAll(List<AgenciaItemEntity> entities)
        {
            IMapper mapper;
            List<AgenciaItem> lista;

            mapper = GetMapperEntityToItem();
            lista = mapper.Map<List<AgenciaItem>>(entities);

            return lista;
        }

        public static AgenciaEntity Get(Agencia item)
        {
            IMapper mapper;
            AgenciaEntity entity;

            mapper = GetMapperDtoToEntity();
            entity = mapper.Map<AgenciaEntity>(item);

            return entity;
        }

        private static IMapper GetMapperEntityToItem()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<AgenciaItemEntity, AgenciaItem>()
                .ForMember(dest => dest.Comentarios, opt => opt.MapFrom(src => GetComentario(src.Comentarios))));
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static IMapper GetMapperEntityToDto()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<AgenciaEntity, Agencia>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        private static object GetComentario(string comentario)
        {
            string comentarioCorto;

            if (!string.IsNullOrEmpty(comentario) && comentario.Length > 19)
                comentarioCorto = comentario.Substring(0, 20) + "...";
            else
                comentarioCorto = comentario;

            return comentarioCorto;
        }

        private static IMapper GetMapperDtoToEntity()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<Agencia, AgenciaEntity>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static AgenciaDetalle GetAgenciaDetalle(AgenciaDetailsEntity entity)
        {
            IMapper mapper;
            AgenciaDetalle item;

            mapper = GetMapperEntityToDetails();
            item = mapper.Map<AgenciaDetalle>(entity);

            return item;
        }

        private static IMapper GetMapperEntityToDetails()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<AgenciaDetailsEntity, AgenciaDetalle>());
            Mapper = Config.CreateMapper();

            return Mapper;
        }

        internal static Agencia Get(AgenciaEntity entity)
        {
            IMapper mapper;
            Agencia item;

            mapper = GetMapperEntityToDto();
            item = mapper.Map<Agencia>(entity);

            return item;
        }

        internal static List<AgenciaItem> GetAllAgenciaItem(List<AgenciaEntity> entities)
        {
            IMapper mapper;
            List<AgenciaItem> lista;

            mapper = GetMapperEntityToAgenciaItem();
            lista = mapper.Map<List<AgenciaItem>>(entities);

            return lista;
        }

        private static IMapper GetMapperEntityToAgenciaItem()
        {
            IMapper Mapper;
            MapperConfiguration Config;
            Config = new MapperConfiguration(cfg => cfg.CreateMap<AgenciaEntity, AgenciaItem>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => $"{src.Clave} {src.Nombre}"))
            );
            Mapper = Config.CreateMapper();

            return Mapper;
        }
    }
}
