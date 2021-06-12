using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Corona_Ventilator.Data;
using Corona_Ventilator.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Corona_Ventilator.Hubs;
using Microsoft.AspNetCore.SignalR;


namespace Corona_Ventilator.Pages.PatientsData
{
    public class IndexModel : PageModel
    {
        List<DateTime> PatientTimeData = new List<DateTime>();
        List<float> PatientO2LevelData = new List<float>();
        string PatientO2LevelData_Json;
        string PatientTimeData_Json;
        bool buttonClicked = false;
        bool _started = false;

        private readonly Corona_Ventilator.Data.Corona_VentilatorContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(Corona_Ventilator.Data.Corona_VentilatorContext context, ILogger<IndexModel> logger)
        {
            Console.WriteLine("************************ I Passed here");
            _context = context;
            _logger = logger;
            Console.WriteLine(_context);

        }

        [BindProperty]
        public string ChartData
        {
            get { return PatientO2LevelData_Json; }
            set { PatientO2LevelData_Json = value; }
        }
        [BindProperty]
        public string ChartTimestamp
        {
            get { return PatientTimeData_Json; }
            set { PatientTimeData_Json = value; }
        }

        //[BindProperty(SupportsGet = true)]
        public IList<Patient> Patient { get; set; }

        public void OnGet()
        {
            GetPatientData();
        }

        public string Message { get; set; }

        //public async Task OnPost()
        //{
        //    Console.WriteLine("************************ Load");
        //    Message = "Post used";
        //    //while (!_started)
        //    //{
        //        GetPatientData();

        //        //PlotLineChart();

        //    //    Thread.Sleep(500);
        //    //}
        //}

        //public async Task OnGetAsync()
        //{
        //    Console.WriteLine("************************ Then Passed here?");
        //    //_context.Patient.AddAsync(PlotLineChart);

        //    Patient = await _context.Patient.AsNoTracking().ToListAsync();
        //    //Thread PlotChart = new Thread(PlotLineChart);
        //    //PlotChart.Start();
        //    PlotLineChart();
        //}

        public void GetPatientData()
        {
            Console.WriteLine("************************ Thread GetPatientData");
            //Patient = await _context.Patient.AsNoTracking().ToListAsync();
            Patient = _context.Patient.ToList();
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

            _started = false;
            //GetPatientData();
            //OnGet();

        }
    }
}