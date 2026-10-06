using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.MetricDataDtos
{
    public partial class GpuMetricsDto : ObservableObject
    {
        [ObservableProperty]
        public float temperature;

    }
}
