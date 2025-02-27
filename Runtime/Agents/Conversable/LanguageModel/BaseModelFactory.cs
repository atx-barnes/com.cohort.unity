using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cohort.Agents.Conversable
{
    public abstract class BaseModelFactory : MonoBehaviour, IModelFactory
    {
        public abstract ILanguageModel Generate<TResponseContent>(string model = null) where TResponseContent : IContent;
    }
}
