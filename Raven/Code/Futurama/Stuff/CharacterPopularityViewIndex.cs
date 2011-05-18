//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using Raven.Client.Indexes;
//using Raven.Database.Indexing;

//namespace Futurama
//{
//    public class CharacterPopularityViewIndex : AbstractIndexCreationTask<PopularityVote, CharacterPopularityView>
//    {
//        public override IndexDefinition CreateIndexDefinition()
//        {
//            var index = new IndexDefinition<PopularityVote, CharacterPopularityView> {
//                Map = votes =>
//                    from vote in votes
//                    select new {
//                        vote.CharacterId,
//                        VoteTotal = vote.Delta
//                    },

//                Reduce = mapped =>
//                    from vote in mapped
//                    group vote by vote.CharacterId into g
//                    select new {
//                        CharacterId = g.Key,
//                        VoteTotal = g.Sum(o => o.VoteTotal)
//                    },

//                TransformResults = (database, results) =>
//                    from result in results
//                    let character = database.Load<Character>(result.CharacterId)
//                    select new {
//                        result.CharacterId,
//                        CharacterName = character.Name,
//                        result.VoteTotal
//                    }
//            };
//            index.SortOptions.Add(x => x.VoteTotal, Raven.Database.Indexing.SortOptions.Int);

//            return index.ToIndexDefinition(DocumentStore.Conventions);
//        }
//    }
//}
