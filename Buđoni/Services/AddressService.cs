using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Budjoni.Services
{
    public class BexAddressService
    {
        private List<Mesto> _mesta;

        public async Task<List<Mesto>> GetMestaAsync()
        {
            using var httpClient = new HttpClient();
            var response =await httpClient.GetAsync("https://shipping.bex.rs/api/vYbkPlaces/");
            return JsonSerializer.Deserialize<List<Mesto>>(response.Content.ReadAsStringAsync().Result);
        }
        public async Task<List<Ulica>> GetUliceAsync(int idMesta)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://shipping.bex.rs/api/vYbkStreets?mestoid={idMesta}");
            return JsonSerializer.Deserialize<List<Ulica>>(response.Content.ReadAsStringAsync().Result);
        }
    }

    public class Mesto
    {
        [JsonPropertyName("IdMesta")]
        public int IdMesta { get; set; }

        [JsonPropertyName("name")]
        public string Naziv { get; set; }

        [JsonPropertyName("title")]
        public string TextZaPrikaz { get; set; }

        [JsonPropertyName("opstina")]
        public string Opstina { get; set; }

        [JsonPropertyName("zip")]
        public int ZIP { get; set; }

        [JsonPropertyName("sort")]
        public int Sort { get; set; }
    }

    public class Ulica
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("mestoid")]
        public int IdMesta { get; set; }

        [JsonPropertyName("name")]
        public string Naziv { get; set; }

        [JsonPropertyName("napomena")]
        public string Napomena { get; set; }
    }

}
