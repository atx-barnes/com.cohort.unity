using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cohort.Agents.Conversable;

namespace Cohort.Samples.AgentOrchestration
{
    [RequireComponent(typeof(ModelFactory))]
    public class ConversableAgentFactory : MonoBehaviour
    {
        [field: SerializeField] public List<ConversableAgentDefinition> Definitions { get; private set; } = new List<ConversableAgentDefinition>();

        public TAgent Generate<TAgent>(string model, Vector3 position = default, Quaternion rotation = default, Transform parent = default) where TAgent : BaseConversableAgent
        {
            foreach (ConversableAgentDefinition definition in Definitions)
            {
                TAgent agent = Instantiate(definition.Prefab, position, rotation, parent).GetComponent<TAgent>();
                agent.Init(definition, GetComponent<ModelFactory>(), model);
                return agent;
            }
            return default(TAgent);
        }
    }
}
