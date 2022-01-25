using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PelisApp.Domain.Entities;

namespace PelisApp.Domain.Interfaces
{
    public interface RepositoryPelis
    {
        Task<IEnumerable<Pelicula>> TodosLosDatos();
        Task<Pelicula> PorID(int id);
        Task<int> create(Pelicula pelicula);
        Task<bool> Update(int id, Pelicula pelicula);
    }
}