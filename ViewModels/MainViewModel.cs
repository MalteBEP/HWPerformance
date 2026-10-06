using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HWPerformance.Adapters.Windows;
using HWPerformance.Interfaces;
using HWPerformance.Models;
using HWPerformance.Models.ComponentDtos;
using HWPerformance.Models.MetricDataDtos;
using HWPerformance.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;


namespace HWPerformance.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    public HardwareSpecsDto hardwareSpecs { get; set; }
    public IWatcher watcher;
    public PerformanceMonitor performanceMonitor;

    [ObservableProperty]
    public MetricDataDto data = new MetricDataDto()
    {
        CpuMetrics = new CpuMetricsDto
        {
            Temperature = 0,
        },

        GpuMetrics = new GpuMetricsDto
        {
            Temperature = 0,
        },
    };

    public MainViewModel()
    {
        watcher = new WindowsAdapter();
        performanceMonitor = new PerformanceMonitor(watcher);
        hardwareSpecs = performanceMonitor.GetHardwareSpecs();

    }

    [RelayCommand]
    private async Task StartMonitoring()
    {
        await performanceMonitor.StartMonitoring(newValue => Data = newValue);
    }

}
