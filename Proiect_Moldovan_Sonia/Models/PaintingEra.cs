using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Moldovan_Sonia.Models
{
    public class PaintingEra
    {
        public int ID { get; set; }
        public int PaintingID { get; set; }
        public Painting Painting { get; set; }
        public int EraID { get; set; }
        public Era Era { get; set; }
    }
}
