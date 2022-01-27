using Blazor_Heroes.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor_Heroes.Client.Service
{
    public class HeroService : IHeroesService
    {
        private readonly HttpClient _httpClient;

        public HeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task GetComics()
        {
          Comics = await _httpClient.GetFromJsonAsync<List<Comic>>("api/hero/comics");
        }

        public async Task<SuperHero> GetHero(int id)
        {
            //Poner siempre la ruta completa del api
            return await _httpClient.GetFromJsonAsync<SuperHero>($"api/hero/{id}");

        }

        public async Task<List<SuperHero>> GetHeroes()
        {
           return await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/hero");
        }

        public async Task<List<SuperHero>> PostHero(SuperHero hero)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/hero/", hero);
            var heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            return heroes;
        }

       
    }
}
