using DataAccess.Mongo.Interfaces;
using Domain.Models;
using Domain.Models.Constants;
using MongoDB.Driver;

namespace DataAccess.Mongo;
public static class Seeder
{
    public static async Task SeedAsync(IDbContext db)
    {
        ArgumentNullException.ThrowIfNull(db);

        await SeedUnits(db);
        await SeedNutrients(db);
    }

    private static async Task SeedUnits(IDbContext db)
    {

        if (await HasData<Unit>(db)) return;

        var units = new List<Unit>
        {
            new() { Name = UnitsConstants.GramName, Code = UnitsConstants.GramCode },
            new() { Name = UnitsConstants.KilogramName, Code = UnitsConstants.KilogramCode },
            new() { Name = UnitsConstants.LiterName, Code = UnitsConstants.LiterCode },
            new() { Name = UnitsConstants.MilliliterName, Code = UnitsConstants.MilliliterCode }
        };

        await db.GetCollection<Unit>().InsertManyAsync(units);
    }
    private static async Task SeedNutrients(IDbContext db)
    {
        if (await HasData<Nutrient>(db)) return;

        var nutrients = new List<Nutrient>
        {
            new() { Name = NutrientNames.Carbohydrates, Unit = new Unit{ Name = UnitsConstants.GramName, Code = UnitsConstants.GramCode }  },
            new() { Name = NutrientNames.Fats, Unit = new Unit{ Name = UnitsConstants.GramName, Code = UnitsConstants.GramCode }  },
            new() { Name = NutrientNames.Fibre, Unit = new Unit { Name = UnitsConstants.GramName, Code = UnitsConstants.GramCode } },
            new() { Name = NutrientNames.Proteins, Unit = new Unit { Name = UnitsConstants.GramName, Code = UnitsConstants.GramCode } },
            new() { Name = NutrientNames.Sugar, Unit = new Unit { Name = UnitsConstants.GramName, Code = UnitsConstants.GramCode } }
        };

        await db.GetCollection<Nutrient>().InsertManyAsync(nutrients);
    }


    private static async Task<bool> HasData<T>(IDbContext db)
    {
        return await db.GetCollection<T>().Find(_ => true).AnyAsync();
    }
}
