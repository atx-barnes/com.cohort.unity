using System;
using Cohort.Common;

namespace Cohort.Agents.Conversable
{
    public interface IConversableAgent<TResponse, TRequest, TFragment> : IAgent<TResponse, TRequest, TFragment> where TResponse : IAgentResponse where TRequest : IAgentRequest where TFragment : IFragment
    {
        Action<string> OnCompleteResponse { get; set; }
        Action<string> OnPartialResponse { get; set; }
        Action<object> OnStructuredResponse { get; set; }

        ILanguageModel LanguageModel { get; set; }
        bool RememberConversation { get; set; }
    }
}
