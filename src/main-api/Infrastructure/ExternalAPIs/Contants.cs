namespace Infrastructure.ExternalAPIs;
public static class Constants
{
    public const string SearchByNameRequest = "https://world.openfoodfacts.org/cgi/search.pl?search_terms={0}&page={1}&page_size={2}&json=1";
    public const string SearchByCodeRequest = "https://world.openfoodfacts.org/api/v0/product/{0}";

}
