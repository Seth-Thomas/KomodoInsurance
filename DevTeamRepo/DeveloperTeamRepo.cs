using DeveloperRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo
{
    public class DeveloperTeamRepo
    {
        // Field to hold all devTeams
        private List<DevTeamContent> _listOfDevTeams = new List<DevTeamContent>();
        //Create
        // Add devTeam to field list
        public void AddDevTeamToList(DevTeamContent team)
        {
            _listOfDevTeams.Add(team);
        }
        //Read
        // Return field list
        public List<DevTeamContent> GetDevTeamList()
        {
            return _listOfDevTeams;
        }

        // Add developer to team
        public void AddDevtoTeam(DeveloperContent developer, string teamName)
        {
            // Get dev team we want to add dev to
            DevTeamContent team = GetDevTeamByTeamName(teamName);
            // Dig into dev team object using dot annotation to get to Developers property (which is a list)
            team.Developers.Add(developer);
            // Add developer to Developers property

        }

        //Update
        public bool UpdateDevTeam(string originalTeam, DevTeamContent newDevTeam)
        {
            //Find the developer
            DevTeamContent oldTeam = GetDevTeamByTeamName(originalTeam);

            //Update developer
            if (oldTeam != null)
            {
                oldTeam.TeamName = newDevTeam.TeamName;
                oldTeam.TeamId = newDevTeam.TeamId;
                oldTeam.Developers = newDevTeam.Developers;
                return true;
            }
            else
            {
                return false;
            }


            //Delete
        }
        public bool RemoveDevTeamFromList(string teamName)
        {
            DevTeamContent devTeam = GetDevTeamByTeamName(teamName);

            if (devTeam == null)
            {
                return false;
            }
            int initialCount = _listOfDevTeams.Count;
            _listOfDevTeams.Remove(devTeam);

            if (initialCount > _listOfDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
            // Return devTeam from field list by team Id
        }

        private void RemoveDevFromTeam(DeveloperContent developer, string teamName)
        {
            DevTeamContent team = GetDevTeamByTeamName(teamName);
            team.Developers.Remove(developer);

        }
        // Helper
        private DevTeamContent GetDevTeamByTeamName(string teamName)
        {

            foreach (DevTeamContent devTeam in _listOfDevTeams)
            {
                if (devTeam.TeamName.ToLower() == teamName.ToLower())
                {
                    return devTeam;
                }
            }
            return null;
        }


    }
}
