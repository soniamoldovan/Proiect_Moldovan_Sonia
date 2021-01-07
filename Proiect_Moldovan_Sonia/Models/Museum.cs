using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Moldovan_Sonia.Models
{
    public class Museum
    {
        public int ID { get; set; }

        [Display(Name = "Name of The Museum")]
        public string MuseumName { get; set; }
        public string Location { get; set; }

        [Display(Name = "Price of one ticket/adult (in USD)")]
        public int TicketPrice { get; set; }
        public ICollection<Painting> Paintings { get; set; }
    }
}
