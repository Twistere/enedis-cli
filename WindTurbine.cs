using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

public class WindTurbine
{
    private static string apiUrl = "https://data.enedis.fr/api/records/1.0/search/?dataset=bilan-electrique-puissance-installee&q=&facet=region&facet=filiere&refine.region=Auvergne-Rh%C3%B4ne-Alpes&refine.filiere=Eolien";
    public static HttpClient client = new HttpClient();
    private static async Task<JObject> GetEnergyBalenceFromWindTurbine(string requestUrl)
    {
        HttpResponseMessage reponse = await client.GetAsync(requestUrl);
        string json = await reponse.Content.ReadAsStringAsync();
        return JObject.Parse(json);
    }

    public async Task<string> GetPower()
    {
        JObject energyBalence = await GetEnergyBalenceFromWindTurbine(apiUrl);
        return energyBalence["records"][0]["fields"]["puissance"].ToString();
    }

}
