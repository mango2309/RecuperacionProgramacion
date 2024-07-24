using Newtonsoft.Json;
using RecuperacionProgramacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperacionProgramacion.Services
{
    public class NarutoApiService
    {
        private readonly HttpClient _httpClient;

        public NarutoApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://narutodb.xyz/") };
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            var response = await _httpClient.GetStringAsync("docs/characters");
            var characters = JsonConvert.DeserializeObject<List<Character>>(response);
            return characters;
        }
    }
}
