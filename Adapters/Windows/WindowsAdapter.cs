using HWPerformance.Interfaces;
using HWPerformance.Models;
using HWPerformance.Models.ComponentDtos;
using HWPerformance.Models.MetricDataDtos;
using LibreHardwareMonitor.Hardware;
using LibreHardwareMonitor.Hardware.Motherboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HWPerformance.Adapters.Windows
{
    internal class WindowsAdapter : IWatcher
    {

        private Computer _computer;
        private UpdateVisitor _updateVisitor;
        private bool _isRunning;

        MetricDataDto metricData = new MetricDataDto
        {
            CpuMetrics = new CpuMetricsDto
            {
                Temperature = 0
            },

            GpuMetrics = new GpuMetricsDto
            {
                Temperature = 0
            },

        };

        public WindowsAdapter()
        {
            _computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsNetworkEnabled = true,
                IsStorageEnabled = true,
                IsPowerMonitorEnabled = true,
            };

            _updateVisitor = new UpdateVisitor();
            _isRunning = true;
            _computer.Open();
        } 

        public event Action<MetricDataDto> OnMetricsPolled;
        public void EnableMetric(HardwareType hardwareType)
        {
            throw new NotImplementedException();
        }
        public void DisableMetric(HardwareType hardwareType)
        {
            throw new NotImplementedException();
        }
        public void StopMonitoring()
        {
            _isRunning = false;
            _computer.Close();
        }

        public async Task StartMonitoring(Action<MetricDataDto> updateFrontend)
        {
            while (_isRunning)
            {
                _computer.Accept(new UpdateVisitor());

                foreach (IHardware hardware in _computer.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.Cpu)
                    {
                        foreach (ISensor sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                metricData.CpuMetrics.Temperature = (float)sensor.Value;
                            }
                        }
                    }
                    else if (hardware.HardwareType == HardwareType.GpuAmd || hardware.HardwareType == HardwareType.GpuNvidia || hardware.HardwareType == HardwareType.GpuIntel)
                    {
                        foreach (ISensor sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                metricData.GpuMetrics.Temperature = (float)sensor.Value;
                            }
                        }
                    }
                }

                updateFrontend(metricData);
                await Task.Delay(1000);
            }
        }


        public HardwareSpecsDto GetHardwareSpecs()
        {
            _computer.Accept(new UpdateVisitor());
            HardwareSpecsDto specs = new HardwareSpecsDto();
            float? totalCapacity = 0;
            foreach (IHardware hardware in _computer.Hardware)
            {
                switch (hardware.HardwareType)
                {
                    // cpu
                    case HardwareType.Cpu:
                        specs.Cpu = new CpuDto
                        {
                            Name = hardware.Name
                        };
                        break;

                    // gpu
                    case HardwareType.GpuAmd:
                    case HardwareType.GpuNvidia:
                    case HardwareType.GpuIntel:
                        specs.Gpu = new GpuDto
                        {
                            Name = hardware.Name
                        };
                        break;

                    // ram
                    case HardwareType.Memory:
                        string memoryName = hardware.Identifier.ToString();
                        if (hardware.Identifier.ToString().Contains("/ram"))
                        {
                            foreach (ISensor sensor in hardware.Sensors)
                            {
                                if (sensor.SensorType == SensorType.Data)
                                {
                                    totalCapacity += sensor.Value;
                                }
                            }
                        }
                        else if (memoryName.Contains("/memory/") && specs.Ram == null)
                        {
                            string[] arr = hardware.Name.Split('-');
                            specs.Ram = new RamDto
                            {
                                Name = arr[0] + Math.Round((decimal)totalCapacity) + " GB",
                            };
                        }

                        break;
                }
              

            }


            return specs;
        }
    }
}
