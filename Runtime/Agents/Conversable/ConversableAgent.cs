using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using System;

namespace Cohort.Agents.Conversable 
{
    public class ConversableAgent<TResponseContent, TRequestContent> : BaseConversableAgent, 
    IConversableAgent<ConversableResponse<TResponseContent>, ConversableRequest<TRequestContent>, ConversableFragment> 
    where TResponseContent : IContent, new() 
    where TRequestContent : IContent
    {
        public override void Init(ConversableAgentDefinition definition, IModelFactory factory, string model)
        {
            Name = definition.Name;
            ID = definition.ID;
            System = definition.System.Content;
            LanguageModel = factory.Generate<TResponseContent>(model);
        }

        public override void Reboot()
        {
            PartialResponseCache = string.Empty;
            if(Cortex is List<ConversableFragment> cortex)
                cortex.RemoveAll(fragment => fragment.Role != IRole.Type.System);
        }

        public async Task<ConversableResponse<TResponseContent>> Execute(ConversableRequest<TRequestContent> request)
        {
            PartialResponseCache = string.Empty;

            if(request.Fragment.Role == IRole.Type.System)
                Cortex.ElementAt(SystemPromptIndex).Content.Message = System = request.Fragment.Content.Message;
            
            Debug.Log($"Executing request: {request.Fragment.Content.Message}");
            Cortex.Add(request.Fragment);

            TResponseContent content = await LanguageModel.RequestCompletion<TResponseContent, ConversableFragment>(Cortex.OfType<ConversableFragment>().OrderBy(fragment => fragment.CreatedAt).ToList());
            ConversableFragment fragment = new ConversableFragment { Role = IRole.Type.Assistant, Content = content };
            Cortex.Add(fragment);

            var debug = new 
            {
                conversation = Cortex.Select(f => new 
                {
                    createdAt = f.CreatedAt,
                    role = f.Role.ToString().ToLower(),
                    prompt = string.IsNullOrEmpty(f.Content.Message) ? "(empty)" : $"{f.Content.Message[..Math.Min(1500, f.Content.Message.Length)]}{(f.Content.Message.Length > 1500 ? "..." : string.Empty)}"
                })
            };

            Debug.Log($"{Name} Current Converstation: {JsonConvert.SerializeObject(debug)}");

            if(!RememberConversation)
                Reboot();

            return new ConversableResponse<TResponseContent>(fragment);
        }

        protected virtual void OnModelCompleteResponse(string response) => OnCompleteResponse?.Invoke(response);
        protected virtual void OnModelPartialResponse(string response) => OnPartialResponse?.Invoke(response);
        protected virtual void ModelStructuredResponse(string response) => OnStructuredResponse?.Invoke(response);
    }
}
