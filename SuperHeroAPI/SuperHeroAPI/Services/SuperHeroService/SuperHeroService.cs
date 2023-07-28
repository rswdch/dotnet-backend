using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService: ISuperHeroService
{
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
    
    public List<SuperHero> GetAllHeroes()
    {
        return heroes;
    }

    public SuperHero GetHero(int id)
    {
        var found = heroes.Find(hero => hero.Id == id);
        if (found == null) { return null; }
        return found;
    }

    public List<SuperHero> AddHero(SuperHero hero)
    {
        heroes.Add(hero);
        return heroes;
    }

    public List<SuperHero> UpdateHero(int id, SuperHero hero)
    {
        var heroToUpdate = heroes.Find(hero => hero.Id == id);
        if (heroToUpdate is null)
        {
            return null;
        }

        heroToUpdate.Name = hero.Name;
        heroToUpdate.FirstName = hero.FirstName;
        heroToUpdate.LastName = hero.LastName;
        heroToUpdate.Place = hero.Place;
        return heroes;
    }

    public List<SuperHero> DeleteHero(int id)
    {
        var heroToDelete = heroes.Find(hero => hero.Id == id);
        if (heroToDelete is null)
        {
            return null;
        }
        heroes.Remove(heroToDelete);
        return heroes;
        throw new NotImplementedException();
    }
}