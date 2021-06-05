using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Corona_Ventilator.Data;
using Corona_Ventilator.Models;
using Newtonsoft.Json;
using System.Web;
using System.Web.Helpers;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json;

namespace Corona_Ventilator.Pages.PatientsData
{
    public class IndexModel : PageModel
    {
        List<DateTime> PatientTimeData = new List<DateTime>();
        List<float> PatientO2LevelData = new List<float>();      
        string PatientO2LevelData_Json;
        string PatientTimeData_Json;

        private readonly Corona_Ventilator.Data.Corona_VentilatorContext _context;

        public IndexModel(Corona_Ventilator.Data.Corona_VentilatorContext context)
        {
            _context = context;
            //Console.WriteLine("Patient" + _context);

        }
        [BindProperty]
        public string ChartData 
        {
            get { return PatientO2LevelData_Json; }
            set { PatientO2LevelData_Json = value; }
        }
        public string ChartTimestamp
        {
            get { return PatientTimeData_Json; }
            set { PatientTimeData_Json = value; }
        }

        public IList<Patient> Patient { get;set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patient.ToListAsync();
            PlotLineChart();
         }

        public void PlotLineChart()
        {
            PatientO2LevelData.Clear();
            PatientTimeData.Clear();

            for (int i = 0; i < Patient.Count; i++)
            {
                Console.WriteLine("Patient: " + Patient[i].O2Level);
                PatientO2LevelData.Add(Patient[i].O2Level);
                PatientTimeData.Add(Patient[i].Timestamp);
            }

            foreach (var item in PatientO2LevelData)
            {
                Console.WriteLine("PatientO2LevelData: " + item);
            }

            PatientO2LevelData_Json = JsonConvert.SerializeObject(PatientO2LevelData);
            PatientTimeData_Json = JsonConvert.SerializeObject(PatientTimeData);
        }

        
    }
}



//[HttpPost]
//public JsonResult NewChart()
//{
//    List<object> iData = new List<object>();
//    //Creating sample data  
//    DataTable dt = new DataTable();
//    dt.Columns.Add("Employee", System.Type.GetType("System.String"));
//    dt.Columns.Add("Credit", System.Type.GetType("System.Int32"));

//    DataRow dr = dt.NewRow();
//    dr["Employee"] = "Sam";
//    dr["Credit"] = 123;
//    dt.Rows.Add(dr);

//    dr = dt.NewRow();
//    dr["Employee"] = "Alex";
//    dr["Credit"] = 456;
//    dt.Rows.Add(dr);

//    dr = dt.NewRow();
//    dr["Employee"] = "Michael";
//    dr["Credit"] = 587;
//    dt.Rows.Add(dr);
//    //Looping and extracting each DataColumn to List<Object>  
//    foreach (DataColumn dc in dt.Columns)
//    {
//        List<object> x = new List<object>();
//        x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
//        iData.Add(x);
//    }
//    //Source data returned as JSON  
//    //return Json(iData, JsonRequestBehavior.AllowGet);
//    //JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
//    //return Json(JsonConvert.SerializeObject(iData, _jsonSetting), "application/json");
//    //return Json(iData, new Newtonsoft.Json.JsonSerializerSettings());
//    return iData;
//}