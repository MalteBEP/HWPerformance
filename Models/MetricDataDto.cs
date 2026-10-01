using HWPerformance.Models.MetricDataDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models
{
    public class MetricDataDto
    {
        public CpuMetricsDto CpuMetrics { get; set; }
        public GpuMetricsDto GpuMetrics { get; set; }
        public MoboMetricsDto MoboMetrics { get; set; }
    }
}
