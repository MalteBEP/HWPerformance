using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.ComponentDtos
{
    public class MoboDto
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
