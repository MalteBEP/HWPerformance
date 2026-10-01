using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.ComponentDtos
{
    public class CpuDto
    {
        public string Name { get; set; }
        public int CoreCount { get; set; }
        public float ClockSpeedGHz { get; set; }
        public override string ToString()
        {
            return $"{Name} ({CoreCount}-Core, {ClockSpeedGHz} GHz)";
        }
    }
}
