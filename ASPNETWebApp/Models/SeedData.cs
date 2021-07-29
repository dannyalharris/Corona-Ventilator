using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona_Ventilator.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Corona_VentilatorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Corona_VentilatorContext>>()))
            {
                Random randNum = Random(100);
                context.Patient.Addrange(

                    Timestamp)
            }
        }
    }
}
