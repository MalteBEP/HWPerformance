using HWPerformance.Models;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HWPerformance.Interfaces
{
    public interface IWatcher
    {
        public event Action<MetricDataDto> OnMetricsPolled;
        public void EnableMetric(HardwareType hardwareType);
        public void DisableMetric(HardwareType hardwareType);
        public void StopMonitoring();
        public Task StartMonitoring(Action<float> updateFrontend);
        public HardwareSpecsDto GetHardwareSpecs();
    }
}
