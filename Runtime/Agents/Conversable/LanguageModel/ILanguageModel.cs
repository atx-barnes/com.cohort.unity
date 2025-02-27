using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cohort.Agents.Conversable
{
    public interface ILanguageModel
    {
        public string Name { get; set; }
        public ICompletionEndpoint Endpoint { get; set; }
        public Task<TModelResponse> RequestCompletion<TModelResponse, TConversable>(List<TConversable> conversables) where TModelResponse : IContent, new() where TConversable : IConversable<IContent>;
    }
}
