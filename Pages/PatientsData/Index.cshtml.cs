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
    public class IndexModel : PageModel
    {
        private readonly Corona_Ventilator.Data.Corona_VentilatorContext _context;

        public IndexModel(Corona_Ventilator.Data.Corona_VentilatorContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patient.ToListAsync();
        }
    }
}
