using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Cohort.Common
{
    public interface IAgent<TResponse, TRequest, TFragment> where TResponse : IAgentResponse where TRequest : IAgentRequest where TFragment : IFragment
    {
        string Name { get; set; }
        string ID { get; set; }
        List<TFragment> Cortex { get; set; }
        Task<TResponse> Execute(TRequest request);
        void Reboot();
    }
}
