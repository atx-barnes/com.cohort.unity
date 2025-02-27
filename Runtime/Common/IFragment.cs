using System;

namespace Cohort.Common
{
    public interface IFragment
    {
        string ID { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
