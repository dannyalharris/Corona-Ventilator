// JavaScript Document

/*------------------------------------------------
 * Created by:
 * Kai Li, Ong
 * Danial Hawari
 *
 * Sommer Semester 2020
 *
 * Corona Ventilator Project
 *
 * More informations: ***
 *
 ************************************************/

var client;
var reconnectTimeout = 2000;
var host = "broker.hivemq.com";
//var host = "broker.emqx.io";
var port = 8000;
//var port = 8083;

MQTTConnect();

function MQTTConnect() {
    // Multiple web-app client can be run at simultaneously to control the 8x8 led
    //client = new Paho.MQTT.Client(host, port, "clientjs");
    //const clientId = 'mqttjs_' + Math.random().toString(16).substr(2, 8);
    //client = new Paho.MQTT.Client("wss://" + host, /*Number(port),*/ "clientId");
    client = new Paho.MQTT.Client(host, port, "clientId");
    // Only one web-app client can be run at one time to prevent other user from controlling the 8x8 led
    //client = new Paho.MQTT.Client(MQTTBroker, Number(MQTTPort), "3136c683-88d2-4825-b3c3-f2ba14a28eae");
    //client = new Paho.MQTT.Client(MQTTBroker, Number(MQTTPort), "clientId");
    client.onConnectionLost = onConnectionLost;
    client.onMessageArrived = onMessageArrived;

    client.connect({
        timeout: 360000,
        onSuccess: onConnect,
        onFailure: onFailure
    });
    console.log("MQTTConnect Thread");
}

function onConnect() {
    console.log("Connected");
    client.subscribe("CoronaVentilator/State");

    var ESPmessage = new Paho.MQTT.Message("Hello World");
    console.log(ESPmessage);
    ESPmessage.destinationName = "CoronaVentilator/Command";
    ESPmessage.qos = 0;
    client.send(ESPmessage);
}
console.log("Testing ABC");

function onFailure() {
    //alert("8x8-WebApp MQTT connection is unable to connect to " + MQTTBroker + " at port " + MQTTPort + "\nPlease check the MQTT broker and MQTT port!");
    //localStorage.setItem("mqttestablished", false);
    console.log("onFailure:" + responseObject.errorMessage);
    //console.log("mqtt status: reconnect");
    MQTTConnect();
}

function onConnectionLost(responseObject) {
    if (responseObject.errorCode !== 0) {
        //localStorage.setItem("mqttestablished", false);
        console.log("onConnectionLost: " + responseObject.errorMessage);
        //alert("Error " + responseObject.errorCode + " ( " + responseObject.errorMessage + " ) " + ": Please disconnect before attempting connection to the MQTT broker next time!");
    }
    MQTTConnect();
};

var StateSetAdr;
var StateSetValue;
var ValueArr = [];
var DataTimeArr = [];
var ValueCountArr = [];

function onMessageArrived(message) {
    console.log("onMessageArrived: " + message.payloadString + " " + message.destinationName);

    var dateTime = new Date().toLocaleString();
    var status = message.payloadString.toString();
    var StatusObj = JSON.parse(status);
    console.log("StatusObj.ADR: " + StatusObj.ADR + ", StatusObj.BAT: " + StatusObj.BAT);
    StateSetAdr = StatusObj.ADR;
    StateSetValue = StatusObj.BAT;
    ValueArr.push(StateSetValue);
    DataTimeArr.push(dateTime);
    ValueCountArr.push(dateTime);
    //console.log(ValueArr);
    //console.log(DataTimeArr);
    //mqttconnected = StatusObj.ADR;
    plotLineChart();
};

//plotLineChart();

var barchart = document.getElementById('bar').getContext('2d');
var mybarchart = new Chart(barchart, {
    type: 'bar',
    data: {
        labels: ['001', '002', '003'],
        datasets: [{
            label: 'Bar Chart',
            data: [100, 200, 300],
            backgroundColor: 'rgba(100,128,200)'
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});

var piechart = document.getElementById('pie').getContext('2d');
var mypiechart = new Chart(piechart, {
    type: 'pie',
    data: {
        labels: ['001', '002', '003'],
        datasets: [{
            label: 'Pie Chart',
            data: [100, 200, 300],
            backgroundColor: 'rgba(6,128,122)'
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});

function plotLineChart() {
    var linechart = document.getElementById('myChart').getContext('2d');
    //console.log("Chart Data : " + @Html.Raw(Model.ChartData));
    //console.log("Chart Time : " + @Html.Raw(Model.ChartTimestamp));
    console.log("Chart Data : " + ValueArr);
    console.log("Chart Time : " + DataTimeArr);
    //console.log("Chart Time : " + ValueCountArr);
    //var auto_refresh = setInterval(
    //    function () {
    var mylinechart = new Chart(linechart, {
        type: 'line',
        data: {
            labels: DataTimeArr/*@Html.Raw(Model.ChartTimestamp)*/,
            datasets: [{
                label: 'Test Data',
                data: ValueArr,/*@Html.Raw(Model.ChartData),*/
                fill: false,
                borderColor: 'rgb(75, 192, 192)',
                tension: 0.1,
             }]
         },
    });
            /*}, 1000);*/
        //window.location = window.location;

    }