/*
  MySQL Connector/Arduino Example : connect by wifi

  This example demonstrates how to connect to a MySQL server from an
  Arduino using an Arduino-compatible Wifi shield. Note that "compatible"
  means it must conform to the Ethernet class library or be a derivative
  with the same classes and methods.

  For more information and documentation, visit the wiki:
  https://github.com/ChuckBell/MySQL_Connector_Arduino/wiki.

  INSTRUCTIONS FOR USE

  1) Change the address of the server to the IP address of the MySQL server
  2) Change the user and password to a valid MySQL user and password
  3) Change the SSID and pass to match your WiFi network
  4) Connect a USB cable to your Arduino
  5) Select the correct board and port
  6) Compile and upload the sketch to your Arduino
  7) Once uploaded, open Serial Monitor (use 115200 speed) and observe

  If you do not see messages indicating you have a connection, refer to the
  manual for troubleshooting tips. The most common issues are the server is
  not accessible from the network or the user name and password is incorrect.

  Note: The MAC address can be anything so long as it is unique on your network.

  Created by: Dr. Charles A. Bell
*/
#include <WiFi.h>                  // Use this for WiFi instead of Ethernet.h
#include <MySQL_Connection.h>
#include <MySQL_Cursor.h>
#include <ESPDateTime.h>
#include <time.h>

char hostname[] = "remotemysql.com";
char user[] = "zFbSD6mmkT";               // MySQL user login username
char password[] = "mKcqTswtyr";           // MySQL user login password
char db[] = "zFbSD6mmkT";

// WiFi card example
const char* ssid = "STRANGER";    // your SSID
const char* pass = "mimomimo";       // your SSID Password

IPAddress server_ip;
WiFiClient client;            // Use this for WiFi instead of EthernetClient
MySQL_Connection conn((Client *)&client);

char INSERT_SQL[] = "INSERT INTO `Patient Data` (Timestamp,O2Level) VALUES ( %s, %s )";
char query[128];
//char O2Level[10];
//char TimeStamp[128];

void setup() {
    Serial.begin(115200);
    delay(10);
    
    // Wifi Section

    Serial.println();
    Serial.println();
    Serial.print("Connecting to ");
    Serial.println(ssid);

    WiFi.begin(ssid, pass);

    while (WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }

    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());

    WiFi.hostByName(hostname,server_ip);
    Serial.println(server_ip);
    // End WiFi section

    // Date Time section 
    DateTime.setTimeZone("2");
    DateTime.begin();
    if (!DateTime.isTimeValid()) {
    Serial.println("Failed to get time from server.");
     }
    // End Date Time section
  
   // Connect to MYSQL
   Serial.println("Connecting...");
   if (conn.connect(server_ip, 3306, user, password, db)) {
   delay(1000);
   }
   else
   Serial.println("Connection failed.");
   //conn.close();
   // End MYSQL section
}

void loop() {
  int  randNumber = random(100);
  String timestamp = String(DateTime.toString());
  String randNum = String(randNumber);
  sprintf(query, INSERT_SQL, timestamp, randNum);
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);
  cur_mem->execute(query);
  Serial.println("Send this message:" + timestamp + " , " + randNum);
  
  delete cur_mem;
  delay(1000);
  
}
