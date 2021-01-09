using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Moldovan_Sonia.Data;


namespace Proiect_Moldovan_Sonia.Models
{
    public class PaintingErasPageModel : PageModel
    {
        public List<AssignedEraData> AssignedEraDataList;
        public void PopulateAssignedEraData(Proiect_Moldovan_SoniaContext context, Painting painting)
        {
            var allEras = context.Era;
            var paintingEras = new HashSet<int>(painting.PaintingEras.Select(c => c.PaintingID));
            AssignedEraDataList = new List<AssignedEraData>();
            foreach (var cat in allEras)
            {
                AssignedEraDataList.Add(new AssignedEraData
                {
                    EraID = cat.ID,
                    Name = cat.EraName,
                    Assigned = paintingEras.Contains(cat.ID)
                });
            }
        }
        public void UpdatePaintingEras(Proiect_Moldovan_SoniaContext context, string[] selectedEras, Painting paintingToUpdate)
        {
            if (selectedEras == null)
            {
                paintingToUpdate.PaintingEras = new List<PaintingEra>();
                return;
            }
            var selectedErasHS = new HashSet<string>(selectedEras);
            var paintingEras = new HashSet<int>
            (paintingToUpdate.PaintingEras.Select(c => c.Era.ID));
            foreach (var cat in context.Era)
            {
                if (selectedErasHS.Contains(cat.ID.ToString()))
                {
                    if (!paintingEras.Contains(cat.ID))
                    {
                        paintingToUpdate.PaintingEras.Add(
                        new PaintingEra
                        {
                            PaintingID = paintingToUpdate.ID,
                            EraID = cat.ID
                        });
                    }
                }
                else
                {
                    if (paintingEras.Contains(cat.ID))
                    {
                        PaintingEra courseToRemove
                        = paintingToUpdate
                        .PaintingEras
                        .SingleOrDefault(i => i.EraID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
