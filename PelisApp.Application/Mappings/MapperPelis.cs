using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PelisApp.Domain.Entities;
using PelisApp.Domain.DTOS.Response;
using PelisApp.Domain.DTOS.Request;

namespace PelisApp.Application.Mappings
{
    public class MapperPelis : Profile
    {
        public MapperPelis()
        {
            CreateMap<Pelicula, ResponsePelis>()

            .ForMember(Inf => Inf.InfoDeLaPelicula, opt => opt.MapFrom(src => $"Título: {src.Titulo}. Dirigida por: {src.Director}"))
            .ForMember(Inf => Inf.ReseñasGenerales, opt => opt.MapFrom(src => $"La puntuación fue de: {src.Puntuacion} y el Rating fue de:  {src.Rating}"));
        }
    }
}