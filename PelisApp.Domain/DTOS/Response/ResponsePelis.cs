using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelisApp.Domain.DTOS.Response
{
    public class ResponsePelis
    {
        public int ID {get; set;}
        public string InfoDeLaPelicula {get; set;}
        public string ReseñasGenerales {get; set;}
        public string FechaPublicacion { get; set; }
    }
}