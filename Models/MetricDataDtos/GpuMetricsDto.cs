using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.MetricDataDtos
{
    public class GpuMetricsDto
    {
        public float Usage { get; set; }
        public float Temperature { get; set; }
        public float PowerUsage { get; set; }
        public float ClockSpeed { get; set; }
        public float MemoryUsage { get; set; }
        public float MemoryClockSpeed { get; set; }

    }
}
