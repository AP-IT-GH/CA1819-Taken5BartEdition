﻿using Models;
using Models.T5B;
using System;
using System.Text;
using System.Collections.Generic;

namespace Interface.T5B
{
    public interface ITeamService
    {
        Team GetTeam(int id);
        ICollection<Team> GetTeams();
        int GetScorePos(int id);
        bool SpelerJoin(int spelerId, int teamId);
        int GetStartPuzzel(int TeamId);
        int GetNewPuzzel(int TeamId);
        Puzzel ActivePuzzel(int Id);
        int ActivePuzzelID(int Id);
        Puzzel SetActivePuzzel(int Id, bool reset);
    }
}