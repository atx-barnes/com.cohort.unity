using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cohort.Common;

namespace Cohort.Agents.Conversable
{
    public class ConversableResponse<T> : BaseAgentResponse where T : IContent
    {
        public T Content { get; }

        public ConversableResponse(ConversableFragment fragment)
        {
            Content = (T)fragment.Content;
        }
    }
}
