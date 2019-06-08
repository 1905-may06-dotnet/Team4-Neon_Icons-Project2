using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class Mapper
    {
        
        public static DomainEntities.Genre Map(Entities.Genre g) => new DomainEntities.Genre
        {
            id = g.Id,
            type = g.Type
        };
        public static Entities.Genre Map(DomainEntities.Genre g) => new Entities.Genre
        {
            Id = g.id,
            Type = g.type
        };
        public static DomainEntities.Location Map(Entities.Locations l) => new DomainEntities.Genre
        {
            id = l.Id,
            location = l.Location
        };
        public static Entities.Locations Map(DomainEntities.Locations l) => new Entities.Locations
        {
            Id = l.id,
            Location = l.location
        };
        public static DomainEntities.Preferences Map(Entities.Preferences p) => new DomainEntities.Preferences
        {
            preferences_id = p.Id,
            user_id = p.UserId,
            weather_id = p.WeatherId,
            genre_id = p.GenreId
        };
        public static Entities.Preferences Map(DomainEntities.Preferences p) => new Entities.Preferences
        {
            Id = p.preferences_id,
            UserId = p.user_id,
            WeatherId = p.weather_id,
            GenreId = p.genre_id
        };
        public static DomainEntities.Users Map(Entities.Users u) => new DomainEntities.Users
        {
            id = u.Id,
            username = u.Username,
            password = u.Password,
            location_id = u.LocationId
        };
        public static Entities.Users Map(DomainEntities.Users u) => new Entities.Users
        {
            Id = u.id,
            Username = u.username,
            Password = u.password,
            LocationId = u.location_id
        };
        public static DomainEntities.Weather Map(Entities.Weather w) => new DomainEntities.Weather
        {
            weather_id = w.Id,
            type = w.Type,
            description = w.Description,
            default_genre = w.DefaultGenre
        };
        public static Entities.Weather Map(DomainEntities.Weather w) => new Entities.Weather
        {
            Id = w.weather_id,
            Type = w.type,
            Description = w.description,
            DefaultGenre = w.default_genre
        };
        public static IEnumerable<DomainEntities.Genre> Map(IEnumerable<Entities.Genre> g) => g.Select(Map);
        public static IEnumerable<Entities.Genre> Map(IEnumerable<DomainEntities.Genre> g) => g.Select(Map);
        public static IEnumerable<DomainEntities.Locations> Map(IEnumerable<Entities.Locations> l) => l.Select(Map);
        public static IEnumerable<Entities.Locations> Map(IEnumerable<DomainEntities.Locations> l) => l.Select(Map);
        public static IEnumerable<DomainEntities.Preferences> Map(IEnumerable<Entities.Preferences> p) => p.Select(Map);
        public static IEnumerable<Entities.Preferences> Map(IEnumerable<DomainEntities.Preferences> p) => p.Select(Map);
        public static IEnumerable<DomainEntities.Users> Map(IEnumerable<Entities.Users> u) => u.Select(Map);
        public static IEnumerable<Entities.Users> Map(IEnumerable<DomainEntities.Users> u) => u.Select(Map);
        public static IEnumerable<DomainEntities.Weather> Map(IEnumerable<Entities.Weather> w) => w.Select(Map);
        public static IEnumerable<Entities.Weather> Map(IEnumerable<DomainEntities.Weather> w) => w.Select(Map);
    }
}
