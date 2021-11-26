using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mountaineering.Models.Entities
{
    public class Mountain
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public DateTime? FirstClimb { get; set; }
        public List<Climber> CurrClimbers { get; set; }
    }
}
