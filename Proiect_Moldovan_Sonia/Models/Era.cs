using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Moldovan_Sonia.Models
{
    public class Era
    {
        public int ID { get; set; }
        public string EraName { get; set; }
        public ICollection<PaintingEra> PaintingEras { get; set; }
    }
}
