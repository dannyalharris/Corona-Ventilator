using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
//using System.Web.Mvc;


namespace Corona_Ventilator.Pages.PatientsData
{
	//[DataContract]
	//public class DataPoint
	//{
	//	public DataPoint(double x, double y)
	//	{
	//		this.X = x;
	//		this.Y = y;
	//	}

	//	//Explicitly setting the name to be used while serializing to JSON.
	//	[DataMember(Name = "x")]
	//	public Nullable<double> X = null;

	//	//Explicitly setting the name to be used while serializing to JSON.
	//	[DataMember(Name = "y")]
	//	public Nullable<double> Y = null;
	//}

	public class IndexModel : PageModel
    {
       
        public void OnGet()
        {

        }
        //GET: Home
        //public ActionResult Index()
        //{
        //    return ;
        //}

  //      public ContentResult JSON()
		//{
		//	List<DataPoint> dataPoints = new List<DataPoint>();


		//	dataPoints.Add(new DataPoint(1481999400000, 4.67));
		//	dataPoints.Add(new DataPoint(1482604200000, 4.7));
		//	dataPoints.Add(new DataPoint(1483209000000, 4.96));
		//	dataPoints.Add(new DataPoint(1483813800000, 5.12));
		//	dataPoints.Add(new DataPoint(1484418600000, 5.08));
		//	dataPoints.Add(new DataPoint(1485023400000, 5.11));
		//	dataPoints.Add(new DataPoint(1485628200000, 5));
		//	dataPoints.Add(new DataPoint(1486233000000, 5.2));
		//	dataPoints.Add(new DataPoint(1486837800000, 4.7));
		//	dataPoints.Add(new DataPoint(1487442600000, 4.74));
		//	dataPoints.Add(new DataPoint(1488047400000, 4.67));
		//	dataPoints.Add(new DataPoint(1488652200000, 4.66));
		//	dataPoints.Add(new DataPoint(1489257000000, 4.86));
		//	dataPoints.Add(new DataPoint(1489861800000, 4.91));
		//	dataPoints.Add(new DataPoint(1490466600000, 5.12));
		//	dataPoints.Add(new DataPoint(1491071400000, 5.4));
		//	dataPoints.Add(new DataPoint(1491676200000, 5.08));
		//	dataPoints.Add(new DataPoint(1492281000000, 5.05));
		//	dataPoints.Add(new DataPoint(1492885800000, 4.98));
		//	dataPoints.Add(new DataPoint(1493490600000, 4.89));
		//	dataPoints.Add(new DataPoint(1494095400000, 4.9));
		//	dataPoints.Add(new DataPoint(1494700200000, 4.95));
		//	dataPoints.Add(new DataPoint(1495305000000, 4.88));
		//	dataPoints.Add(new DataPoint(1495909800000, 5.07));
		//	dataPoints.Add(new DataPoint(1496514600000, 5.14));
		//	dataPoints.Add(new DataPoint(1497119400000, 5.05));
		//	dataPoints.Add(new DataPoint(1497724200000, 5.03));
		//	dataPoints.Add(new DataPoint(1498329000000, 4.93));
		//	dataPoints.Add(new DataPoint(1498933800000, 4.97));
		//	dataPoints.Add(new DataPoint(1499538600000, 4.86));
		//	dataPoints.Add(new DataPoint(1500143400000, 4.95));
		//	dataPoints.Add(new DataPoint(1500748200000, 4.83));
		//	dataPoints.Add(new DataPoint(1501353000000, 4.83));
		//	dataPoints.Add(new DataPoint(1501957800000, 4.73));
		//	dataPoints.Add(new DataPoint(1502562600000, 4.56));
		//	dataPoints.Add(new DataPoint(1503167400000, 4.34));
		//	dataPoints.Add(new DataPoint(1503772200000, 4.25));
		//	dataPoints.Add(new DataPoint(1504377000000, 4.18));
		//	dataPoints.Add(new DataPoint(1504981800000, 4.22));
		//	dataPoints.Add(new DataPoint(1505586600000, 4.18));
		//	dataPoints.Add(new DataPoint(1506191400000, 4.31));
		//	dataPoints.Add(new DataPoint(1506796200000, 4.34));
		//	dataPoints.Add(new DataPoint(1507401000000, 4.47));
		//	dataPoints.Add(new DataPoint(1508005800000, 4.57));
		//	dataPoints.Add(new DataPoint(1508610600000, 4.63));
		//	dataPoints.Add(new DataPoint(1509215400000, 4.55));
		//	dataPoints.Add(new DataPoint(1509820200000, 4.55));
		//	dataPoints.Add(new DataPoint(1510425000000, 4.44));
		//	dataPoints.Add(new DataPoint(1511029800000, 4.46));
		//	dataPoints.Add(new DataPoint(1511634600000, 4.41));
		//	dataPoints.Add(new DataPoint(1512239400000, 4.3));
		//	dataPoints.Add(new DataPoint(1512844200000, 4.31));
		//	dataPoints.Add(new DataPoint(1513449000000, 4.3));
		//	dataPoints.Add(new DataPoint(1513621800000, 4.36));


		//	JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
		//	return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
		//}

	}
}


