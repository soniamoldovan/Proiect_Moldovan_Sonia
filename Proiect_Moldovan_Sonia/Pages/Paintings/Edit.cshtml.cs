using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Moldovan_Sonia.Data;
using Proiect_Moldovan_Sonia.Models;

namespace Proiect_Moldovan_Sonia.Pages.Paintings
{
    public class EditModel : PaintingErasPageModel
    {
        private readonly Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext _context;

        public EditModel(Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Painting Painting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Painting = await _context.Painting
                .Include(b => b.Museum)
                .Include(b => b.PaintingEras).ThenInclude(b => b.Era)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            if (Painting == null)
            {
                return NotFound();
            }

            PopulateAssignedEraData(_context, Painting);

            ViewData["MuseumID"] = new SelectList(_context.Set<Museum>(), "ID", "MuseumName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedEras)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paintingToUpdate = await _context.Painting
            .Include(i => i.Museum)
            .Include(i => i.PaintingEras)
            .ThenInclude(i => i.Era)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (paintingToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Painting>(
            paintingToUpdate,
            "Book",
            i => i.Name, i => i.Artist,
            i => i.Price, i => i.Museum))
            {
                UpdatePaintingEras(_context, selectedEras, paintingToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdatePaintingEras(_context, selectedEras, paintingToUpdate);
            PopulateAssignedEraData(_context, paintingToUpdate);
            return Page();
        }
    }
    
}
