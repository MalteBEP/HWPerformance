using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.MetricDataDtos
{
    public partial class CpuMetricsDto : ObservableObject
    {
        [ObservableProperty]
        public int temperature;

    }
}
