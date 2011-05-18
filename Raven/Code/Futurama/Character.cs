using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Futurama
{
    public class Character
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> Traits { get; set; }

        public string BestFriend { get; set; }

        public Character()
        {
            Traits = new List<string>();
        }

        public Character(string name, params string[] traits)
        {
            Name = name;
            Traits = new List<string>(traits);
        }

        public override string ToString()
        {
            return string.Format("Character: {0} ({1})", Name, Id);
        }
    }

    public class CharacterReference
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
