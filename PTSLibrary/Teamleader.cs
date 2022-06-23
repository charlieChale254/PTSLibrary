using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    class TeamLeader : User
    {
        private int teamId;
        private int id;
        private string name;
       

        public int TeamId
        {
            get { return teamId; }
            set { teamId = value; }
        }

        public TeamLeader(string name, int id, int teamId)
        {
            this.name = name;
            this.id = id;
            this.teamId = teamId;
        }
    }
}