//using System.Linq;
//using Futurama.Models;
//using Raven.Client.Indexes;

//namespace Futurama
//{
//    public class CharacterTotalVoteIndex : AbstractIndexCreationTask<PopularityVote, CharacterTotalVote>
//    {
//        public CharacterTotalVoteIndex()
//        {
//            Map = votes =>
//                from vote in votes
//                select new {
//                    vote.CharacterId,
//                    VoteTotal = vote.Delta
//                };

//            Reduce = mapped =>
//                from vote in mapped
//                group vote by vote.CharacterId
//                into g
//                select new {
//                    CharacterId = g.Key,
//                    VoteTotal = g.Sum(o => o.VoteTotal)
//                };

//            TransformResults = (database, results) =>
//                from result in results
//                let character = database.Load<Character>(result.CharacterId)
//                select new {
//                    result.CharacterId,
//                    CharacterName = character.Name,
//                    result.VoteTotal
//                };

//            SortOptions.Add(x => x.VoteTotal, Raven.Abstractions.Indexing.SortOptions.Int);
//        }
//    }
//}