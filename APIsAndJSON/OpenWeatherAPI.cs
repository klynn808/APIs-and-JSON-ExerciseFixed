using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class OpenWeatherAPI
    {
        public static void ShalimarWeather()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            string apiKey = config["APIKey:WeatherKey"];
            string city = "Shalimar,US";

            var client = new HttpClient();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=32579,US&units=imperial&appid={apiKey}";
            
            var response = client.GetStringAsync(weatherURL).Result;

            JObject formattedResponse = JObject.Parse(response);
            var temp = formattedResponse["main"]["temp"];

            Console.WriteLine($"...And now for your Shalimar, Florida weather update!");
            Console.WriteLine("_____________________");

            var description = formattedResponse["weather"][0]["description"];
            Console.WriteLine($"The temperature in Shalimar is: {temp}, and there may be {description}.");

        }
    }
}
