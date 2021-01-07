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
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext _context;

        public DeleteModel(Proiect_Moldovan_Sonia.Data.Proiect_Moldovan_SoniaContext context)
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

            Painting = await _context.Painting.FirstOrDefaultAsync(m => m.ID == id);

            if (Painting == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Painting = await _context.Painting.FindAsync(id);

            if (Painting != null)
            {
                _context.Painting.Remove(Painting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
