using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cohort.Agents.Conversable
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Definition", menuName = "Cohort/Agents/Definition", order = 1)]
    public class ConversableAgentDefinition : ScriptableObject
    {
        [field: SerializeField] public BaseConversableAgent Prefab { get; set; }
        [field: SerializeField] public string ID { get; set; }
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public Prompt System { get; set; }
    }
}
