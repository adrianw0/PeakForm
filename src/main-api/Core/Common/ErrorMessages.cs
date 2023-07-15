using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common;
public static class ErrorCodes
{
    public const string UpdateFailed = "UpdateFailed";
    public const string DeleteFailed = "DeleteFailed";

    public const string NotFound = "NotFound";

    public const string ProductsNotFound = "ProductsNotFound";

    public const string MealsNotFound = "MealsNotFound";
    public const string MealUpdateFailed = "MealUpdateFailed";


    public const string SomethingWentWrong = "SomethingWentWront";

    public const string UnitDoesNotExist = "UnitDoesNotExist";
    public const string DuplicateUnitInProduct = "DuplicateUnitInProduct";
    public const string BaseUnitDoesNotExistInProductUnits = "BaseUnitDoesNotExistInProductUnits";


}
