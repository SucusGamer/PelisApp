using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PelisApp.Domain.Entities;
using PelisApp.Domain.Interfaces;

namespace PelisApp.Application.Services
{
    public class ServicesPelis : ServicePelis
    {
        public bool ValidacionPeli (Pelicula pelicula)
        {
            if(string.IsNullOrEmpty(pelicula.Titulo))
                return false;

            if(string.IsNullOrEmpty(pelicula.Director))
                return false;

            if(string.IsNullOrEmpty(pelicula.Genero))
                return false;

            if(string.IsNullOrEmpty(pelicula.FechaPublicacion))
                return false;

            return true;
        }

        public bool ValidacionActualizarPeli (Pelicula pelicula)
        {
            if(string.IsNullOrEmpty(pelicula.Titulo))
                return false;

            if(string.IsNullOrEmpty(pelicula.Director))
                return false;

            if(string.IsNullOrEmpty(pelicula.Genero))
                return false;

            if(string.IsNullOrEmpty(pelicula.FechaPublicacion))
                return false;

            return true;
        } 
    }
}