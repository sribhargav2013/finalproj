
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using finalproj.Models;
using Newtonsoft.Json;

namespace finalproj
{
    public interface IDataImporter
    {
        Task ImportData();
    }

    public class DataImporter : IDataImporter
    {
        private readonly DataContext _context;
        private readonly HttpClient _httpClient;

        public DataImporter(DataContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", "g4NYr2GeuQeyTN6Icn2zPhVGA2jeeqnhAYvaIvjz");
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task ImportData()
        {
            string apiPath = "https://data.kingcounty.gov/resource/yaai-7frk.json";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiPath);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var pets = JsonConvert.DeserializeObject<Pet[]>(data);

                    // Save pets to the database
                    foreach (var pet in pets)
                    {
                        _context.Pets.Add(pet);
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                // Handle exceptions (logging or display an error message)
                Console.WriteLine(e.Message);
            }
        }
    }
}
