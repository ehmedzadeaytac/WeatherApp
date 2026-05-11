using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherService
    {
        private readonly string _apiKey = "a85cf6556b4b2cb8c1891639c144422c";
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task GetWeatherAsync(string city)
        {
            using HttpClient client = new HttpClient();
            string url = $"{_baseUrl}?q={city}&appid={_apiKey}&units=metric&lang=en";

            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<WeatherResponse>(jsonString);

                    Console.WriteLine("\n============================");
                    Console.WriteLine($"City: {data.Name}");
                    Console.WriteLine($"Temperature: {data.Main.Temp}°C");
                    Console.WriteLine($"Feels Like: {data.Main.Feels_Like}°C");
                    Console.WriteLine($"Condition: {data.Weather[0].Description}");
                    Console.WriteLine($"Wind Speed: {data.Wind.Speed} m/s");
                    Console.WriteLine($"Humidity: {data.Main.Humidity}%");
                    Console.WriteLine("============================\n");
                }
                else
                {
                    Console.WriteLine("Error: City not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection Error: {ex.Message}");
            }
        }
    }
}