using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cohort.Agents.Conversable
{
    public abstract class BaseConversableAgent : MonoBehaviour
    {
        public Action<string> OnCompleteResponse { get; set; }
        public Action<string> OnPartialResponse { get; set; }
        public Action<object> OnStructuredResponse { get; set; }

        public bool RememberConversation { get; set; } = true;
        protected string PartialResponseCache { get; set; }
        protected int SystemPromptIndex => 0;

        public string ID { get; set; }
        public string Name { get; set; }

        public List<ConversableFragment> Cortex { get; set; } = new List<ConversableFragment>() { new ConversableFragment { Role = IRole.Type.System, Content = new Text { Message = "You are a helpful assistant." } } };

        private string system;
        public string System
        {
            get => system;
            set
            {
                system = value;
                if(Cortex is List<ConversableFragment> cortex)
                {
                    cortex[SystemPromptIndex].Content.Message = value;
                }
            }
        }

        private ILanguageModel languageModel;
        public ILanguageModel LanguageModel
        {
            get => languageModel;
            set => languageModel = value;
        }

        public abstract void Init(ConversableAgentDefinition definition, IModelFactory factory, string model);
        public abstract void Reboot();
    }
}
