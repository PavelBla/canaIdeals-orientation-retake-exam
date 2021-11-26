using Mountaineering.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mountaineering.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Climber> Climbers { get; set; }
        public List<Mountain> Mountains { get; set; }
        public Mountain Mountain { get; set; }
        public Climber Climber { get; set; }
        public int Level { get; set; }
    }
}
