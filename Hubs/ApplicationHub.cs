using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Corona_Ventilator.Models;


namespace Corona_Ventilator.Hubs
{
    public class ApplicationHub : Hub
    {

        List<DateTime> PatientTimeData = new List<DateTime>();
        List<float> PatientO2LevelData = new List<float>();
        string PatientO2LevelData_Json;
        string PatientTimeData_Json;

        private readonly Corona_Ventilator.Data.Corona_VentilatorContext _context;

        public IList<Patient> Patient { get; set; }

        public ApplicationHub (Corona_Ventilator.Data.Corona_VentilatorContext context)
        {
            _context = context;
            Console.WriteLine("Hub: " + _context);
            Patient = _context.Patient.ToList();
            foreach (var item in Patient)
            {
                Console.WriteLine("PatientHub: " + item);
            }
        }

        public async Task PlotLineChart()
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

            //PatientO2LevelData_Json = JsonConvert.SerializeObject(PatientO2LevelData);
            //PatientTimeData_Json = JsonConvert.SerializeObject(PatientTimeData);

            //await Clients.All.SendAsync("ReceiveMessage", PatientO2LevelData_Json, PatientTimeData_Json);
        }

        public async Task Broadcast(string PatientO2LevelValue, string PatientTimeValue)
        {
            PatientO2LevelValue = JsonConvert.SerializeObject(PatientO2LevelData);
            PatientTimeValue = JsonConvert.SerializeObject(PatientTimeData);

            await Clients.All.SendAsync("ReceiveMessage", PatientO2LevelValue, PatientTimeValue);
            //    {
            //    PatientO2LevelValue = PatientO2LevelData_Json;
            //    PatientTimeValue = PatientTimeData_Json;
            //});

        }


    }
}
