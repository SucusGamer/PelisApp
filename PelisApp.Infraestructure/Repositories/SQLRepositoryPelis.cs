using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PelisApp.Infraestructure.Data;
using PelisApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PelisApp.Domain.Interfaces;
#pragma warning restore format


namespace PelisApp.Infraestructure.Repositories
{
    public class SQLRepositoryPelis : RepositoryPelis
    {
    private readonly BaseDeDatosContext _context;

        public SQLRepositoryPelis(BaseDeDatosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pelicula>> TodosLosDatos()
        {
            var encuentro = _context.Peliculas.Select(g => g);
            return await encuentro.ToListAsync();
        }

        public async Task<Pelicula> PorID(int id)
        {
            var poi = await _context.Peliculas.FirstOrDefaultAsync(dn => dn.ID == id);
            return poi;
        }


        //Crear denuncia
        public async Task<int> create(Pelicula pelicula)
        {
            var entity = pelicula;
            await _context.Peliculas.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("Error, el registro no se pudo completar.");
            
            return entity.ID;
        }

        //Actualizar denuncia
        public async Task<bool> Update(int id, Pelicula pelicula)
        {
            if(id <= 0 || pelicula == null)
                throw new ArgumentException("Falta agregar información. Por favor, revise la información");

            var entity = await PorID(id);

            entity.Titulo = pelicula.Titulo;
            entity.Director = pelicula.Director;
            entity.Genero = pelicula.Genero;
            entity.Puntuacion = pelicula.Puntuacion;
            entity.Rating = pelicula.Rating;
            entity.FechaPublicacion = pelicula.FechaPublicacion;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}