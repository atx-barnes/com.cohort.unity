using UnityEngine;

namespace Cohort.Agents.Conversable
{
    public interface IContent
    {
        public string Message { get; set; }
    }

    public interface IImage : IContent
    {
        public Texture2D Image { get; set; }
    }

    public interface IStructure : IContent
    {

    }
}
