using UnityEngine;

namespace Cohort.Agents.Conversable
{
    [CreateAssetMenu(fileName = "Prompt", menuName = "Cohort/Agents/Prompt")]
    public class Prompt : ScriptableObject
    {
        [TextArea(2, 10)] public string Content;
    }
}
