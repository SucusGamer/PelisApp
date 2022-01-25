using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelisApp.Domain.DTOS.Request
{
    public class RequestPelis
    {
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Puntuacion { get; set; }
        public decimal Rating { get; set; }
        public string FechaPublicacion { get; set; }   
    }
}