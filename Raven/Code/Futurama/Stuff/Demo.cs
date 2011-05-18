//using System;
//using System.Linq;
//using System.Reflection;
//using Raven.Client;
//using Raven.Client.Document;
//using Raven.Client.Indexes;

//namespace Futurama
//{
//    public class Demo
//    {
//        private readonly IDocumentStore store;

//        public Demo()
//        {
//            store = new DocumentStore {
//                Url = "http://localhost:8080",
//            };
//            store.Initialize();
//        }

//        public void DoStuff()
//        {
//            LoadAll();
//        }

//        #region Create Characters

//        public void CreateCharacters()
//        {
//            using(var session = store.OpenSession())
//            {
//                var bender = new Character("Bender", "Alcoholic", "Chain-smoker", "Shiny metal ass");
//                bender.BestFriend = "characters/2"; // Fry
//                bender.Appearances.Add(new Appearance {Episode = "episode/1", TimeOnScreen = 5});

//                var fry = new Character("Fry", "Dumb", "From the past");
//                var flexo = new Character("Flexo", "Evil", "Goatee");

//                session.Store(bender);
//                session.Store(fry);
//                session.Store(flexo);
//                session.SaveChanges();
//            }
//        }

//        #endregion

//        #region Query By Name

//        public void QueryByName(string name)
//        {
//            using(var session = store.OpenSession())
//            {
//                var query = from robot in session.Query<Character>()
//                    where robot.Name.StartsWith(name)
//                    select robot;

//                Print(query);
//            }
//        }

//        #endregion

//        #region Loading - Nested

//        public void LoadNested()
//        {
//            using(var session = store.OpenSession())
//            {
//                var bender = session.Load<Character>("characters/1");
//                var friend = session.Load<Character>(bender.BestFriend);

//                Print(bender, friend);
//            }
//        }

//        #endregion

//        #region Loading - Includes

//        public void LoadIncludes()
//        {
//            using(var session = store.OpenSession())
//            {
//                var bender = session.Include<Character>(o => o.BestFriend)
//                    .Load("characters/1");
//                var friend = session.Load<Character>(bender.BestFriend);

//                Print(bender, friend);
//            }
//        }

//        #endregion

//        #region Loading - All

//        public void LoadAll()
//        {
//            using(var session = store.OpenSession())
//            {
//                var characters = session.Load<Character>("characters/1", "characters/2");
//                Print(characters);
//            }
//        }

//        #endregion

//        #region Create Votes

//        public void CreateVotes()
//        {
//            using(var session = store.OpenSession())
//            {
//                var rand = new Random();

//                for(int i = 0; i < 100; i++)
//                {
//                    var vote = new PopularityVote {
//                        CharacterId = "characters/" + rand.Next(1, 4),
//                        Delta = rand.Next(-1, 2)
//                    };

//                    session.Store(vote);
//                }

//                session.SaveChanges();
//            }
//        }

//        #endregion

//        #region Create Indexes

//        public void CreateIndexes()
//        {
//            IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), store);
//        }

//        #endregion

//        #region Indexed Query

//        public void IndexedQuery()
//        {
//            using(var session = store.OpenSession())
//            {
//                var query = session.Query<CharacterPopularityView, CharacterPopularityViewIndex>()
//                    .Customize(x => x.WaitForNonStaleResults());

//                var popularity = from view in query
//                    orderby view.VoteTotal descending
//                    select view;

//                Print(popularity);
//            }
//        }

//        #endregion

//        #region Utility Stuff

//        

//        #endregion
//    }
//}