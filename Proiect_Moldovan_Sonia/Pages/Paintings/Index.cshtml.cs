using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Moldovan_Sonia.Data;
using Proiect_Moldovan_Sonia.Models;

namespace Proiect_Moldovan_Sonia.Pages.Paintings
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext _context;

        public IndexModel(Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext context)
        {
            _context = context;
        }

        public IList<Painting> Painting { get; set; }
        public PaintingData PaintingD { get; set; }
        public int PaintingID { get; set; }
        public int EraID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PaintingD = new PaintingData();

            PaintingD.Paintings = await _context.Painting
            .Include(b => b.Museum)
            .Include(b => b.PaintingEras)
            .ThenInclude(b => b.Era)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                PaintingID = id.Value;
                Painting painting = PaintingD.Paintings
                .Where(i => i.ID == id.Value).Single();
                PaintingD.Eras = painting.PaintingEras.Select(s => s.Era);
            }
        }

    }
}
