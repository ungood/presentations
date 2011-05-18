using System;
using System.Linq;
using System.Reflection;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace Futurama
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var store = new DocumentStore {
                Url = "http://localhost:8080",
            };
            store.Initialize();

            using(var session = store.OpenSession())
            {
                var query = session.Query<CharacterPopularityView, CharacterPopularityViewIndex>()
                    .Customize(x => x.WaitForNonStaleResults());

                var popularity = from view in query
                    orderby view.VoteTotal descending
                    select view;

                Print(popularity);
            }
        }

        public static void Print <T>(IQueryable<T> query)
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