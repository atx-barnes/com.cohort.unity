using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cohort.Agents.Conversable
{
    public interface ICompletionEndpoint
    {
        public Action<string> OnCompleteResponse { get; set; }
        public Action<string> OnPartialResponse { get; set; }
        public Action<object> OnStructuredResponse { get; set; }
        public Task<TContent> Send<TContent, TConversable>(IEnumerable<TConversable> conversables) where TContent : IContent, new() where TConversable : IConversable<IContent>;
    }
}
