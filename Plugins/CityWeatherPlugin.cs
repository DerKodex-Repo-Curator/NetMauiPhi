using Microsoft.SemanticKernel;
using NetMauiPhi.Helpers;
using System.ComponentModel;

namespace NetMauiPhi.Plugins
{
    public class CityWeatherPlugin
    {
        HttpClient client = new HttpClient();

        [KernelFunction]
        [Description("Describes the current weather conditions of a given city")]
        public async Task<string> GetWeather(
            [Description("The name of the city ")] string city)
        {
            var query = $"{Constants.OpenWeatherMapEndpoint}?q={city}&appid={Constants.OpenWeatherMapApiKey}";

            var result = await client.GetAsync(query);

            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return "Error, the weather of the city is not available at this moment";
        }
    }
}
