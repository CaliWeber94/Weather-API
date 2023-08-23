using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using File = System.IO.File;





var apiKeyObject = File.ReadAllText("appsettings.json");
var apiKey = JObject.Parse(apiKeyObject).GetValue("apiKey").ToString();

Console.WriteLine("Enter zip code.");
var zip = Console.ReadLine();

var url = ($"https://api.openweathermap.org/data/2.5/weather?zip={zip},us&appid={apiKey}&units=imperial");

var client = new HttpClient();

var response = client.GetStringAsync(url).Result;

var weatherObject = JObject.Parse(response);

Console.WriteLine($"This is the weather for today: {weatherObject}");



