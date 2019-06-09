using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;

namespace Domain.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}
