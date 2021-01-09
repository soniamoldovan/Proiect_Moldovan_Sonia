using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Moldovan_Sonia.Data;
using Proiect_Moldovan_Sonia.Models;

namespace Proiect_Moldovan_Sonia.Pages.Paintings
{
    public class CreateModel : PaintingErasPageModel
    {
        private readonly Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext _context;

        public CreateModel(Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MuseumID"] = new SelectList(_context.Set<Museum>(), "ID", "MuseumName");

            var painting = new Painting();
            painting.PaintingEras = new List<PaintingEra>();
            PopulateAssignedEraData(_context, painting);

            return Page();
        }

        [BindProperty]
        public Painting Painting { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedEras)
        {
            var newPainting = new Painting();
            if (selectedEras != null)
            {
                newPainting.PaintingEras = new List<PaintingEra>();
                foreach (var cat in selectedEras)
                {
                    var catToAdd = new PaintingEra
                    {
                        EraID = int.Parse(cat)
                    };
                    newPainting.PaintingEras.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Painting>(
            newPainting,
            "Painting",
            i => i.Name, i => i.Artist,
            i => i.Price, i => i.Museum, i => i.MuseumID))
            {
                _context.Painting.Add(newPainting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedEraData(_context, newPainting);
            return Page();
        }
    }
}
