﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Interface.T5B;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;

namespace BusinessLayer.T5B
{
    public class SessieService : ISessieService
    {
        private ISessionRepository _sessieRepo;

        public SessieService(GameContext context)
        {
            _sessieRepo = new SessieRepository(context);
        }
        public SessieService(ISessionRepository sessieRepo)
        {
            _sessieRepo = sessieRepo;
        }

        public Sessie GetSessie(int id)
        {
            Sessie s = _sessieRepo.GetSessie(id);
            return s;
        }

        public ICollection<Sessie> GetSessies()
        {
            ICollection<Sessie> s = _sessieRepo.GetSessies();
            return s;
        }

        public ICollection<Team> GetTeamsBySessie(int sessieId)
        {
            var s = _sessieRepo.GetSessie(sessieId);
            ICollection<Team> t = null;
            if(s != null)
            {
                t = s.Teams;
            }
            return t;
        }
    }
}