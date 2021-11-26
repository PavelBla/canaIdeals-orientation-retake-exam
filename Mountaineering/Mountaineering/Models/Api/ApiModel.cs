using Mountaineering.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mountaineering.Models.ViewModels
{
    public class ApiModel
    {
        public List<Climber> Climbers { get; set; }

        public ApiModel(List<Climber> climbers)
        {
            Climbers = climbers;
        }
    }
}
