using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService: ISuperHeroService
{
    private readonly DataContext _context;
    public SuperHeroService(DataContext context)
    {
        _context = context;
    }
    private static  List<SuperHero> heroes = 
        new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name="Spider Man",
                FirstName="Peter",
                LastName="Parker",
                Place = "New York City"
            },
            new SuperHero
            {
                Id = 2,
                Name="Iron Man",
                FirstName="Tony",
                LastName="Stark",
                Place = "Malibu"
            }
        };

    public async Task<List<SuperHero>> GetAllHeroes()
    {
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero> GetHero(int id)
    {
        var found = await _context.FindAsync<SuperHero>(id);
        if (found == null) { return null; }
        return found;
    }

    public async Task<List<SuperHero>> AddHero(SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>> UpdateHero(int id, SuperHero hero)
    {
        var heroToUpdate = await _context.FindAsync<SuperHero>(id);
        if (heroToUpdate is null)
        {
            return null;
        }

        heroToUpdate.Name = hero.Name;
        heroToUpdate.FirstName = hero.FirstName;
        heroToUpdate.LastName = hero.LastName;
        heroToUpdate.Place = hero.Place;

        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>> DeleteHero(int id)
    {
        var heroToDelete = await _context.FindAsync<SuperHero>(id);
        if (heroToDelete is null)
        {
            return null;
        }
        _context.SuperHeroes.Remove(heroToDelete);
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
        throw new NotImplementedException();
    }
}