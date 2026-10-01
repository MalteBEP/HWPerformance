using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.MetricDataDtos
{
    public class CpuMetricsDto
    {
        public float CoreUsage { get; set; }
        public float CoreTemperature { get; set; }
        public float Usage { get; set; }
        public float Temperature { get; set; }

    }
}
