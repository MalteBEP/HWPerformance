using HWPerformance.Adapters;
using HWPerformance.Adapters.Windows;
using HWPerformance.Interfaces;
using HWPerformance.Models;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HWPerformance.Services
{
    public class PerformanceMonitor
    {
        private IWatcher watcher;

        public PerformanceMonitor(IWatcher watcher)
        {
            this.watcher = watcher;
        }

        public async Task StartMonitoring(Action<float> updateFrontend)
        {
            await watcher.StartMonitoring(updateFrontend);
        }

        public void StopMonitoring()
        {
            watcher.StopMonitoring();
        }

        public void EnableMetric(HardwareType hardwareType)
        {
            watcher.EnableMetric(hardwareType);
        }

        public void DisableMetric(HardwareType hardwareType)
        {
            watcher.DisableMetric(hardwareType);
        }

        public HardwareSpecsDto GetHardwareSpecs()
        {
            return watcher.GetHardwareSpecs();
        }
    }
}
