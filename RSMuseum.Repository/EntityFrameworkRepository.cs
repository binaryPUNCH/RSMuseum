﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RSMuseum.Repository.Entities;
using RSMuseum.Repository;
using RSMuseum.Repository.Entities;

namespace RSMuseum.Repository
{
    public class EntityFrameworkRepository : IDbRepository
    {
        private RSM_EF_DbCtx.RSMContext dbctx;

        public EntityFrameworkRepository(RSM_EF_DbCtx.RSMContext dbctx) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            this.dbctx = dbctx;
        }

        public void AddTimeRegistration(Registration registration)
        {
            dbctx.Registration.Add(registration);
            dbctx.SaveChanges();
        }

        public IList<Guild> GetAllGuilds()
        {
            var query = dbctx.Guild.ToList();
            return query;
        }

        public IList<object> GetAllNotConfirmedRegistrations()
        {
            throw new NotImplementedException();
        }

        public IList<Volunteer> GetAllVolunteers()
        {
            return dbctx.Volunteer.ToList();
        }

        public IList<Volunteer> GetAllVolunteersAndGuilds()
        {
            //dbctx.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //dbctx.Configuration.ProxyCreationEnabled = false;
            //dbctx.Configuration.LazyLoadingEnabled = false;

            var query = dbctx.Volunteer
                .Include(x => x.Person)
                .Include(x => x.Guilds)
                .ToList();

            return query;
        }
    }
}