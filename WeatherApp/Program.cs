using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var weatherService = new WeatherService();

            Console.WriteLine("--- Weather Forecast System ---");

            while (true)
            {
                Console.Write("Enter city name (or type 'exit' to quit): ");
                string city = Console.ReadLine();

                if (city.ToLower() == "exit")
                {
                    break;
                }

                if (!string.IsNullOrWhiteSpace(city))
                {
                    await weatherService.GetWeatherAsync(city);
                }
                else
                {
                    Console.WriteLine("Please enter a valid city name.");
                }
            }
        }
    }
}