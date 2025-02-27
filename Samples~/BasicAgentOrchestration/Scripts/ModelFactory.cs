using UnityEngine;
using Cohort.Agents.Conversable;

namespace Cohort.Samples.AgentOrchestration
{
    public class ModelFactory : BaseModelFactory
    {
        public override ILanguageModel Generate<TResponseContent>(string model = null)
        {
            switch(model)
            {
                case "GPT-4o":
                    return new LanguageModel(model, new OpenAIEndpoint<TResponseContent>());
                default:
                    break;
            }
            return default;
        }
    }
}
