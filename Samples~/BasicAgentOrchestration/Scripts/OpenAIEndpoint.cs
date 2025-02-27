using UnityEngine;
using OpenAI;
using System;
using OpenAIRole = OpenAI.Role;
using OpenAIMessage = OpenAI.Chat.Message;
using OpenAIContent = OpenAI.Content;
using OpenAI.Chat;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Cohort.Agents.Conversable;

namespace Cohort.Samples.AgentOrchestration
{
    public class OpenAIEndpoint<TObject> : ICompletionEndpoint where TObject : IContent
    {
        private OpenAIClient Client { get; set; }
        public Action<string> OnCompleteResponse { get; set; }
        public Action<string> OnPartialResponse { get; set; }
        public Action<object> OnStructuredResponse { get; set; }

        public OpenAIEndpoint()
        {
            Client = new OpenAIClient(new OpenAIAuthentication().LoadFromDirectory("/Users/jacksonbarnes/.openai"));
        }

        private OpenAIRole MapRole(IRole.Type role)
        {
            switch(role)
            {
                case IRole.Type.System:
                    return OpenAIRole.System;
                case IRole.Type.User:
                    return OpenAIRole.User;
                case IRole.Type.Assistant:
                    return OpenAIRole.Assistant;
                default:
                    return OpenAIRole.User;
            }
        }

        private ChatRequest ConstructRequest<TConversable>(IEnumerable<TConversable> conversables) where TConversable : IConversable<IContent>
        {
            List<OpenAIMessage> messages = conversables.Select((conversable) => 
            {
                if(conversable.Content is MultiModal multiModal)
                {
                    if(multiModal.Image != null)
                    {
                        return new OpenAIMessage(MapRole(conversable.Role),
                            new List<OpenAIContent> 
                            {
                                multiModal.Message,
                                multiModal.Image
                            }
                        );
                    }
                    else
                    {
                        return new OpenAIMessage(MapRole(conversable.Role),
                            new List<OpenAIContent> 
                            {
                                multiModal.Message
                            }
                        );
                    }
                }
                else if(conversable.Content is Text text)
                {
                    return new OpenAIMessage(MapRole(conversable.Role),
                        new List<OpenAIContent> 
                        {
                            text.Message
                        }
                    );
                }else{
                    return default;
                }
            }).ToList();
            return new ChatRequest(messages);
        }

        public async Task<TResponse> Send<TResponse, TConversable>(IEnumerable<TConversable> conversables)
            where TResponse : IContent, new()
            where TConversable : IConversable<IContent>
        {
            TResponse response = new TResponse();
            try
            {
                if(response is IStructure)
                {
                    var(@object, res) = await Client.ChatEndpoint.GetCompletionAsync<TResponse>(ConstructRequest(conversables));
                    response = @object;
                    response.Message = JsonConvert.SerializeObject(response);
                    OnStructuredResponse?.Invoke(response);
                    return response;
                }

                ChatResponse stream = await Client.ChatEndpoint.StreamCompletionAsync(ConstructRequest(conversables), async partial => 
                {
                    if(partial.FirstChoice != null)
                        OnPartialResponse?.Invoke(partial.FirstChoice.Delta?.ToString());
                    await Task.CompletedTask;
                });

                OnCompleteResponse?.Invoke(stream.FirstChoice);
                response.Message = stream.FirstChoice;
                return response;
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                response.Message = "ERROR";
                return response;
            }
        }
    }
}
