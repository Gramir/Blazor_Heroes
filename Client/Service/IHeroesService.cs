using Blazor_Heroes.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Heroes.Client.Service
{
    public interface IHeroesService
    {
        List<Comic> Comics { get; set; }
        Task<List<SuperHero>> GetHeroes();

        Task GetComics();
        Task<SuperHero> GetHero(int id);

        Task<List<SuperHero>> PostHero(SuperHero hero);
    }
}
