using Core.Models;
using Core.Models.Constants;
using DataAccess.Mongo.Interfaces;
using Domain.Models;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Mongo;
public class Seeder
{
    public static async Task SeedAsync(IDbContext db)
    {
       if (db is null) throw new ArgumentNullException(nameof(db));

        await SeedUnits(db);
        await SeedNutrients(db);
    }

    private static async Task SeedUnits(IDbContext db)
    {
        
        if (await HasData<Unit>(db)) return;

        List<Unit> Units = new List<Unit>
        {
            new Unit{ Name = UnitsContants.GramName, Code = UnitsContants.GramCode },
            new Unit{ Name = UnitsContants.KilogramName, Code = UnitsContants.KilogramCode },
            new Unit{ Name = UnitsContants.LiterName, Code = UnitsContants.LiterCode },
            new Unit{ Name = UnitsContants.MiliLiterName, Code = UnitsContants.MililiterCode }
        };

        await db.GetCollection<Unit>().InsertManyAsync(Units);
    }
    private static async Task SeedNutrients(IDbContext db)
    {
        if (await HasData<Nutrient>(db)) return;

        List<Nutrient> Nutrients = new List<Nutrient>
        {
            new Nutrient { Name = NutrientNames.Carbohydrates, Unit = new Unit{ Name = UnitsContants.GramName, Code = UnitsContants.GramCode }  },
            new Nutrient { Name = NutrientNames.Fats, Unit = new Unit{ Name = UnitsContants.GramName, Code = UnitsContants.GramCode }  },
            new Nutrient { Name = NutrientNames.Fibre, Unit = new Unit { Name = UnitsContants.GramName, Code = UnitsContants.GramCode } },
            new Nutrient { Name = NutrientNames.Proteins, Unit = new Unit { Name = UnitsContants.GramName, Code = UnitsContants.GramCode } },
            new Nutrient { Name = NutrientNames.Sugar, Unit = new Unit { Name = UnitsContants.GramName, Code = UnitsContants.GramCode } }
        };
        await db.GetCollection<Nutrient>().InsertManyAsync(Nutrients);
    }


    private static async Task<bool> HasData<T>(IDbContext db)
    {
        return await db.GetCollection<T>().Find(_=>true).AnyAsync();
    }
}
