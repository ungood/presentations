using System;
using System.Collections.Generic;

namespace Futurama.Models
{
    public class PopularityVote
    {
        public string CharacterId { get; set; }
        public string UserId { get; set; }
        public int Delta { get; set; } // +1, 0, -1

        #region Mock Data

        public static IEnumerable<PopularityVote> MockData()
        {
            var rand = new Random();

                for(int i = 0; i < 100; i++)
                {
                    yield return new PopularityVote {
                        CharacterId = "characters/" + rand.Next(1, 4),
                        Delta = rand.Next(-1, 2)
                    };
                }
        }

        #endregion
    }

    public class CharacterTotalVote
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
