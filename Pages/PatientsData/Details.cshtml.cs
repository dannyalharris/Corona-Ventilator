using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Corona_Ventilator.Data;
using Corona_Ventilator.Models;

namespace Corona_Ventilator.Pages.PatientsData
{
    public class DetailsModel : PageModel
    {
        private readonly Corona_Ventilator.Data.Corona_VentilatorContext _context;

        public DetailsModel(Corona_Ventilator.Data.Corona_VentilatorContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient.FirstOrDefaultAsync(m => m.ID == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
