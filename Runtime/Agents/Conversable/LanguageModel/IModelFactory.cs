using UnityEngine;

namespace Cohort.Agents.Conversable
{
    public interface IModelFactory
    {
        public ILanguageModel Generate<TResponseContent>(string model = null) where TResponseContent : IContent;
    }
}
