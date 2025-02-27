using System;

namespace Cohort.Common
{
    public abstract class BaseAgentRequest : IAgentRequest
    {
        public string ID { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseAgentRequest()
        {
            ID = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
