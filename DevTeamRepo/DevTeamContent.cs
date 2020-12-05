using DeveloperRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo
{
    public class DevTeamContent
    {
        public List<DeveloperContent> Developers{ get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }




        public DevTeamContent() { }
        public DevTeamContent( List<DeveloperContent>developers, string teamName, int teamId)
        {
            Developers = developers;
            TeamName = teamName;
            TeamId = teamId;
            

        }
    }
}
