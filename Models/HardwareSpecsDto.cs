using HWPerformance.Models.ComponentDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models
{
    public class HardwareSpecsDto
    {
        public GpuDto Gpu { get; set; }
        public CpuDto Cpu { get; set; }
        public MoboDto Mobo { get; set; }
        public RamDto Ram { get; set; }
        public StorageDto Storage { get; set; }

    }
}
