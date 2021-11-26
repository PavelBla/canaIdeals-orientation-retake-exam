using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mountaineering.Models.Entities
{
    public class Climber
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public int CurrentAltitude { get; set; }
        public bool IsInjured { get; set; }
        public Mountain Mountain { get; set; }
        public long MountainId { get; set; }
    }
}
