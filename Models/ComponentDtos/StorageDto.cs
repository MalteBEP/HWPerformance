using System;
using System.Collections.Generic;
using System.Text;

namespace HWPerformance.Models.ComponentDtos
{
    public class StorageDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Capacity} GB)";
        }
    }
}
