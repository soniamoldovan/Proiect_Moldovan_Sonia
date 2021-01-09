using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Moldovan_Sonia.Models
{
    public class PaintingData
    {
        public IEnumerable<Painting> Paintings { get; set; }
        public IEnumerable<Era> Eras { get; set; }
        public IEnumerable<PaintingEra> PaintingEras { get; set; }
    }
}
