using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cohort.Agents.Conversable
{
    public class LanguageModel : ILanguageModel
    {
        public ICompletionEndpoint Endpoint { get; set; }

        public string Name { get; set; }

        public LanguageModel(string name, ICompletionEndpoint endpoint)
        {
            Name = name;
            Endpoint = endpoint;
        }

        public async Task<TModelResponse> RequestCompletion<TModelResponse, TConversable>(List<TConversable> conversables)
            where TModelResponse : IContent, new()
            where TConversable : IConversable<IContent>
        {
            return await Endpoint.Send<TModelResponse, TConversable>(conversables);
        }
    }
}
