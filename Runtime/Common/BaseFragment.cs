using System;

namespace Cohort.Common
{
    public abstract class BaseFragment : IFragment
    {
        public string ID { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public BaseFragment()
        {
            ID = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
