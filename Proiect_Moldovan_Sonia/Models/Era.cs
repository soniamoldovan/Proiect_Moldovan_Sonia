using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Moldovan_Sonia.Models
{
    public class Era
    {
        public int ID { get; set; }

        [Display(Name = "Name of the Era")]
        public string EraName { get; set; }
        public ICollection<PaintingEra> PaintingEras { get; set; }
    }
}
