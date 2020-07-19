using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

    public class SolarPanel
    {

        private static string apiUrl = "https://data.enedis.fr/api/records/1.0/search/?dataset=bilan-electrique-puissance-installee&q=&facet=region&facet=filiere&refine.region=Auvergne-Rh%C3%B4ne-Alpes&refine.filiere=Photovolta%C3%AFque";
        public static  HttpClient client = new HttpClient();

        private static async Task<JObject> GetEnergyBalenceFromSolarPanel(string requestUrl)
        {
            HttpResponseMessage reponse = await client.GetAsync(requestUrl);
            string json = await reponse.Content.ReadAsStringAsync();
            return JObject.Parse(json);
        }

        public async Task<string> getPower()
        {
            JObject energyBalence = await GetEnergyBalenceFromSolarPanel(apiUrl);
            return energyBalence["records"][0]["fields"]["puissance"].ToString();
        }

    }