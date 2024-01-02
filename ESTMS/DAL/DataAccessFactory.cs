using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User,int,User> UserData()
        {
            return new UserRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Player, int, Player> PlayerData()
        {
            return new PlayerRepo();
        }

        public static IRepo<Organizer, int, Organizer> OrganizerData()
        {
            return new OrganizerRepo();
        }

        public static IRepo<Team, int, Team> TeamData()
        {
            return new TeamRepo();
        }
        public static IRepo<Game, int, Game> GameData()
        {
            return new GameRepo();
        }

        public static IRepo<Sponsor, int, Sponsor> SponsorData()
        {
            return new SponsorRepo();
        }

        public static IRepo<Tournament, int, Tournament> TournamentData()
        {
            return new TournamentRepo();
        }

        public static IRepo<Match, int, Match> MatchData()
        {
            return new MatchRepo();
        }

        public static IRepo<Organization, int, Organization> OrganizationData()
        {
            return new OrganizationRepo();
        }
        public static IRepo<TournamentTeamDetail, int, TournamentTeamDetail> TournamentTeamDetailData()
        {
            return new TournamentTeamDetailRepo();
        }

        public static ITournamentSearch<Tournament,string> TournamentSearchData()
        {
            return new TournamentRepo();
        }
        public static IMatchStat<Match, int> MatchStatData()
        {
            return new MatchRepo();
        }

        public static IRepo<TeamDetail, int, TeamDetail> TeamDetailData()
        {
            return new TeamDetailRepo();
        }

        public static ITournament<Tournament> TournamentFilterData()
        {
            return new TournamentRepo();
        }
        public static ITournamentTeamStat<TournamentTeamDetail, int> TournamentTeamStatData()
        {
            return new TournamentTeamDetailRepo();
        }

    }
}
