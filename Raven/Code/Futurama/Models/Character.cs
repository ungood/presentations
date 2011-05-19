using System.Collections.Generic;

namespace Futurama.Models
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BestFriend { get; set; }
        public List<string> Traits { get; set; }
        public List<Appearance> Appearances { get; set; }

        public int TotalTimeOnScreen { get; set; }

        public Character()
        {
            Appearances = new List<Appearance>();
            Traits = new List<string>();
        }

        public override string ToString()
        {
            var traits = string.Join(", ", Traits.ToArray());
            return string.Format("Character: {0} ({1}) [{2}]", Name, Id, traits);
        }

        #region Mock Data

        public static IEnumerable<Character> MockData()
        {
            var bender = new Character {
                Name = "Bender",
                BestFriend = "characters/2",
                Traits = new List<string> {
                    "Alcoholic",
                    "Chain-smoker",
                    "Shiny metal ass"
                },
                Appearances = new List<Appearance> {
                    new Appearance {
                        Episode = "episodes/1",
                        TimeOnScreen = 10
                    }
                }
            };

            var fry = new Character {
                Name = "Fry",
                BestFriend = "characters/1",
                Traits = new List<string> {
                    "Dumb",
                    "From the past"
                },
                Appearances = new List<Appearance> {
                    new Appearance {
                        Episode = "episodes/1",
                        TimeOnScreen = 15
                    },
                    new Appearance {
                        Episode = "episodes/2",
                        TimeOnScreen = 15
                    }
                }
            };

            var flexo = new Character {
                Name = "Flexo",
                Traits = new List<string> {
                    "Evil",
                    "Goatee"
                }
            };

            return new[] {bender, fry, flexo};
        }

        #endregion
    }

    public class Appearance
    {
        public string Episode { get; set; }
        public int TimeOnScreen { get; set; }
    }
}