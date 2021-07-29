using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Corona_Ventilator.Models;

namespace Corona_Ventilator.Data
{
    public class Corona_VentilatorContext : DbContext
    {
        public Corona_VentilatorContext (DbContextOptions<Corona_VentilatorContext> options)
            : base(options)
        {
        }

        public DbSet<Corona_Ventilator.Models.Patient> Patient { get; set; }
    }
}
