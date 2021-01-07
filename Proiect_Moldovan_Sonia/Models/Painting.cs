using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Moldovan_Sonia.Models
{
    public class Painting
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }

        [Display(Name = "Estimated Price (in millions USD)")]
        public int Price { get; set; }
        public int MuseumID { get; set; }
        public Museum Museum { get; set; }
        public ICollection<PaintingEra> PaintingEras { get; set; }
    }
}
