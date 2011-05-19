using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Futurama.Models;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Raven.Client.Linq;

namespace Futurama
{
    public class Demo
    {
        private readonly IDocumentStore store;

        public Demo()
        {
            store = new EmbeddableDocumentStore {
                DataDirectory = "C:\\temp\\futurama",
                UseEmbeddedHttpServer = true,
            };
            store.Initialize();

            IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), store);
        }

        public void CreateCharacters()
        {
            using(var session = store.OpenSession())
            {
                foreach(var character in Character.MockData())
                    session.Store(character);
                session.SaveChanges();
            }
        }

        public void CreateVotes()
        {
            using(var session = store.OpenSession())
            {
                foreach(var vote in PopularityVote.MockData())
                    session.Store(vote);

                session.SaveChanges();
            }
        }

        public void LoadNested()
        {
            using(var session = store.OpenSession())
            {
                var bender = session.Load<Character>("characters/1");
                var friend = session.Load<Character>(bender.BestFriend);

                Print(bender, friend);
            }
        }

        public void LoadIncludes()
        {
            using(var session = store.OpenSession())
            {
                var bender = session.Include<Character>(o => o.BestFriend)
                    .Load("characters/1");
                var friend = session.Load<Character>(bender.BestFriend);

                Print(bender, friend);
            }
        }

        public void LoadAll()
        {
            using(var session = store.OpenSession())
            {
                var characters = session.Load<Character>("characters/1", "characters/2");
                Print(characters);
            }
        }

        public void QueryByName(string name)
        {
            using(var session = store.OpenSession())
            {
                var query = from robot in session.Query<Character>()
                    where robot.Name.StartsWith(name)
                    select robot;


                Print(query);
            }
        }

        public void QueryByTrait(string trait)
        {
            using(var session = store.OpenSession())
            {
                var query = session.Advanced.LuceneQuery<Character>()
                    .WhereContains("Traits", trait);
                Print(query);
            }
        }

        public void IndexedQuery()
        {
            using(var session = store.OpenSession())
            {
                var query = session.Query<CharacterTotalVote, CharacterTotalVoteIndex>()
                    .Customize(x => x.WaitForNonStaleResults());

                var popularity = from view in query
                    orderby view.VoteTotal descending
                    select view;

                Print(popularity);
            }
        }

        public static void Print <T>(IEnumerable<T> query)
        {
            foreach(var item in query.ToArray())
                Console.WriteLine(item);
        }

        public static void Print(params Character[] objects)
        {
            foreach(var item in objects)
                Console.WriteLine(item);
        }
    }
}