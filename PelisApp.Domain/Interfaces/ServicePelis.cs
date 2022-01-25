using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PelisApp.Domain.Entities;

namespace PelisApp.Domain.Interfaces
{
    public interface ServicePelis
    {
        bool ValidacionPeli(Pelicula pelicula);
        bool ValidacionActualizarPeli(Pelicula pelicula);    
    }
}