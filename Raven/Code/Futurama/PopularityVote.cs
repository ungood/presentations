using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Futurama
{
    public class PopularityVote
    {
        public string CharacterId { get; set; }
        public string UserId { get; set; }
        public int Delta { get; set; } // +1, 0, -1
    }

    public class CharacterPopularityView
    {
        public string CharacterId { get; set; }
        public string CharacterName { get; set; }
        public int VoteTotal { get; set; }

        public override string ToString()
        {
            return CharacterName + " : " + VoteTotal;
        }
    }
}
