using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cohort.Common;

namespace Cohort.Agents.Conversable
{
    public class ConversableFragment : BaseFragment, IConversable<IContent>
    {
        public IRole.Type Role { get; set; }
        public IContent Content { get; set; }
    }
}
