using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cohort.Agents.Conversable
{
    public class MultiModal : Text, IImage
    {
        public Texture2D Image { get; set; }
    }
}
