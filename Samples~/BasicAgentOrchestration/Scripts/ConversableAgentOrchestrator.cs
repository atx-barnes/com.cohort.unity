using UnityEngine;
using Cohort.Agents.Conversable;

namespace Cohort.Samples.AgentOrchestration
{
    public class ConversableAgentOrchestrator : MonoBehaviour
    {
        [field: SerializeField] ConversableAgentFactory AgentFactory { get; set; }

        private async void Start()
        {
            BasicConversableAgent agent = AgentFactory.Generate<BasicConversableAgent>(model: "GPT-4o", parent: transform);
            ConversableResponse<Text> response = await agent.Execute(new ConversableRequest<Text>(IRole.Type.User, new Text { Message = "Hello World" }));
            Debug.Log(response.Content.Message);
        }
    }
}
