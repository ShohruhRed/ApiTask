using Newtonsoft.Json;

namespace API.Data
{
    public class DataContext
    {
        public async Task<List<User>> LoadJson()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient
                    .GetStringAsync("https://raw.githubusercontent.com/ShohruhRed/ApiTask/a1577c76b4d4bd7366a08ee93bcb277ca9ccd336/MOCK_DATA.json");

                var obj = JsonConvert.DeserializeObject<List<User>>(json);
                
                return obj;
            }            
        }
    }
}
