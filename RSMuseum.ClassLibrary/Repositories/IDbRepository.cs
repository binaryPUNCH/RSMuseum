﻿using RSMuseum.ClassLibrary.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RSMuseum.ClassLibrary.Repositories
{
    public interface IDbRepository // Vores main repository, alle andre repositories skal nedarve denne
    {
        IList<object> GetAllNotConfirmedRegistrations();

        IList<Volunteer> GetAllVolunteers();

        IList<Volunteer> GetAllVolunteersAndGuilds();


        void AddTimeRegistration(Registration registration);
    }
}