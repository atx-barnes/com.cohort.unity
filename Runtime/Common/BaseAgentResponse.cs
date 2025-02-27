using System;

namespace Cohort.Common
{
    public abstract class BaseAgentResponse : IAgentResponse
    {
        public string ID { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseAgentResponse()
        {
            ID = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
