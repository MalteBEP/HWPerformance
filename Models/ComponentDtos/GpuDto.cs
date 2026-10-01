using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.ComponentDtos
{
    public class GpuDto
    {
        public string Name { get; set; }
        public int Vram { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Vram} GB)";
        }
    }
}
