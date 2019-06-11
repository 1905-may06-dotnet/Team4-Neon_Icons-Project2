using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DomainEntities;
using Domain.Repositories;

namespace Data.Repositories
{
    class GenreRepository : IGenreRepository
    {
        public IEnumerable<Genre> GetGenres()
        {
            return Mapper.Map(DatabaseInstance.GetContext().Genre);
        }
        public void Create(Genre genre)
        {
            DatabaseInstance.GetContext().Add(Mapper.Map(genre));
        }
        public Genre Find(int genreId)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Genre.FirstOrDefault(g => g.Id == genreId));
        }
    }
}
