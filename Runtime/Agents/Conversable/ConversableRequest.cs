using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cohort.Common;

namespace Cohort.Agents.Conversable
{
    public class ConversableRequest<TContent> : BaseAgentRequest where TContent : IContent
    {
        public ConversableFragment Fragment;

        public ConversableRequest(IRole.Type role, TContent content)
        {
            Fragment = new ConversableFragment { Role = role, Content = content };
        }
    }
}
