﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;
using DomainEntities = Domain.DomainEntities;

namespace Data
{
    public static class Mapper
    {
        public static DomainEntities.Preference Map(Entities.Preferences p)
        {
            if (p == null) { return null; }

            return new DomainEntities.Preference
            {
                preference_id = p.Id,
                user_id = p.UserId,
                weather_id = p.WeatherId,
                genre = p.Genre
            };
        }

        public static Entities.Preferences Map(DomainEntities.Preference p)
        {
            if (p == null) { return null; }

            return new Entities.Preferences
            {
                Id = p.preference_id,
                UserId = p.user_id,
                WeatherId = p.weather_id,
                Genre = p.genre
            };
        }

        public static DomainEntities.User Map(Entities.Users u)
        {
            if (u == null) { return null; }

           return new DomainEntities.User
            {
                id = u.Id,
                username = u.Username,
                password = u.Password,

                location = u.Location
            };
        }

        public static Entities.Users Map(DomainEntities.User u)
        {
            if (u == null) { return null; }

            return new Entities.Users
            {
                Id = u.id,
                Username = u.username,
                Password = u.password,
                Location = u.location
            };
        }

        public static DomainEntities.Weather Map(Entities.Weather w)
        {
            if (w == null) { return null; }

            return new DomainEntities.Weather
            {
                weather_id = w.Id,
                type = w.Type,
                description = w.Description,
                default_genre = w.DefaultGenre
            };
        }

        public static Entities.Weather Map(DomainEntities.Weather w)
        {
            if (w == null) { return null; }

            return new Entities.Weather
            {
                Id = w.weather_id,
                Type = w.type,
                Description = w.description,
                DefaultGenre = w.default_genre
            };
        }

        public static IEnumerable<DomainEntities.Preference> Map(IEnumerable<Entities.Preferences> p) => p.Select(Map);
        public static IEnumerable<Entities.Preferences> Map(IEnumerable<DomainEntities.Preference> p) => p.Select(Map);
        public static IEnumerable<DomainEntities.User> Map(IEnumerable<Entities.Users> u) => u.Select(Map);
        public static IEnumerable<Entities.Users> Map(IEnumerable<DomainEntities.User> u) => u.Select(Map);
        public static IEnumerable<DomainEntities.Weather> Map(IEnumerable<Entities.Weather> w) => w.Select(Map);
        public static IEnumerable<Entities.Weather> Map(IEnumerable<DomainEntities.Weather> w) => w.Select(Map);
    }
}
