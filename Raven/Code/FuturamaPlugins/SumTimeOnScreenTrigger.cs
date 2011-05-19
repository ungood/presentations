using System.Linq;
using Newtonsoft.Json.Linq;
using Raven.Abstractions.Data;
using Raven.Database.Plugins;
using Raven.Json.Linq;

namespace FuturamaPlugins
{
    public class SumTimeOnScreenTrigger : AbstractPutTrigger
    {
        public override void OnPut(string key, RavenJObject document, RavenJObject metadata, TransactionInformation transactionInformation)
        {
            if(metadata == null)
                return;

            var entityName = metadata["Raven-Entity-Name"];
            if(entityName == null || entityName.Value<string>() != "Characters")
                return;

            var sum = document["Appearances"].Values()
                .Sum(app => app.Value<int>("TimeOnScreen"));

            document["TotalTimeOnScreen"] = new RavenJValue(sum);
        }
    }
}
