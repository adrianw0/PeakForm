#pragma warning disable
using Domain.Models;
using Newtonsoft.Json;

namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;

public class _1
{
    public Sizes sizes { get; set; }
    public object uploaded_t { get; set; }
    public string uploader { get; set; }
}

public class _100
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _2
{
    public Sizes sizes { get; set; }
    public object uploaded_t { get; set; }
    public string uploader { get; set; }
}

public class _200
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _3
{
    public Sizes sizes { get; set; }
    public object uploaded_t { get; set; }
    public string uploader { get; set; }
}

public class _4
{
    public Sizes sizes { get; set; }
    public int uploaded_t { get; set; }
    public string uploader { get; set; }
}

public class _400
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _5
{
    public Sizes sizes { get; set; }
    public int uploaded_t { get; set; }
    public string uploader { get; set; }
}

public class _6
{
    public Sizes sizes { get; set; }
    public int uploaded_t { get; set; }
    public string uploader { get; set; }
}

public class Adjustments
{
    public OriginsOfIngredients origins_of_ingredients { get; set; }
    public Packaging packaging { get; set; }
    public ProductionSystem production_system { get; set; }
    public ThreatenedSpecies threatened_species { get; set; }
}

public class AggregatedOrigin
{
    public string epi_score { get; set; }
    public string origin { get; set; }
    public int percent { get; set; }
    public object transportation_score { get; set; }
}

public class Agribalyse
{
    public string agribalyse_food_code { get; set; }
    public string agribalyse_proxy_food_code { get; set; }
    public double co2_agriculture { get; set; }
    public double co2_consumption { get; set; }
    public double co2_distribution { get; set; }
    public double co2_packaging { get; set; }
    public double co2_processing { get; set; }
    public double co2_total { get; set; }
    public double co2_transportation { get; set; }
    public string code { get; set; }
    public string dqr { get; set; }
    public double ef_agriculture { get; set; }
    public double ef_consumption { get; set; }
    public double ef_distribution { get; set; }
    public double ef_packaging { get; set; }
    public double ef_processing { get; set; }
    public double ef_total { get; set; }
    public double ef_transportation { get; set; }
    public int is_beverage { get; set; }
    public string name_en { get; set; }
    public string name_fr { get; set; }
    public int score { get; set; }
    public string version { get; set; }
    public string warning { get; set; }
}

public class CategoriesProperties
{
    [JsonProperty("agribalyse_proxy_food_code:en")]
    public string agribalyse_proxy_food_codeen { get; set; }

    [JsonProperty("ciqual_food_code:en")]
    public string ciqual_food_codeen { get; set; }
}

public class CategoryProperties
{
    [JsonProperty("ciqual_food_name:en")]
    public string ciqual_food_nameen { get; set; }

    [JsonProperty("ciqual_food_name:fr")]
    public string ciqual_food_namefr { get; set; }
}

public class Display
{
    public string en { get; set; }
    public string pl { get; set; }
}

public class EcoscoreData
{
    public Adjustments adjustments { get; set; }
    public Agribalyse agribalyse { get; set; }
    public string grade { get; set; }
    public Grades grades { get; set; }
    public Missing missing { get; set; }
    public int missing_data_warning { get; set; }
    public int missing_key_data { get; set; }
    public PreviousData previous_data { get; set; }
    public int score { get; set; }
    public Scores scores { get; set; }
    public string status { get; set; }
    public int? missing_agribalyse_match_warning { get; set; }
}

public class Front
{
    public Display display { get; set; }
    public Small small { get; set; }
    public Thumb thumb { get; set; }
}

public class FrontEn
{
    public object angle { get; set; }
    public string geometry { get; set; }
    public string imgid { get; set; }
    public string normalize { get; set; }
    public string rev { get; set; }
    public Sizes sizes { get; set; }
    public string white_magic { get; set; }
    public string x1 { get; set; }
    public string x2 { get; set; }
    public string y1 { get; set; }
    public string y2 { get; set; }
    public string coordinates_image_size { get; set; }
}

public class FrontPl
{
    public string angle { get; set; }
    public string coordinates_image_size { get; set; }
    public string geometry { get; set; }
    public string imgid { get; set; }
    public string normalize { get; set; }
    public string rev { get; set; }
    public Sizes sizes { get; set; }
    public string white_magic { get; set; }
    public string x1 { get; set; }
    public string x2 { get; set; }
    public string y1 { get; set; }
    public string y2 { get; set; }
}

public class Full
{
    public int h { get; set; }
    public int w { get; set; }
}

public class Grades
{
    public string ad { get; set; }
    public string al { get; set; }
    public string at { get; set; }
    public string ax { get; set; }
    public string ba { get; set; }
    public string be { get; set; }
    public string bg { get; set; }
    public string ch { get; set; }
    public string cy { get; set; }
    public string cz { get; set; }
    public string de { get; set; }
    public string dk { get; set; }
    public string dz { get; set; }
    public string ee { get; set; }
    public string eg { get; set; }
    public string es { get; set; }
    public string fi { get; set; }
    public string fo { get; set; }
    public string fr { get; set; }
    public string gg { get; set; }
    public string gi { get; set; }
    public string gr { get; set; }
    public string hr { get; set; }
    public string hu { get; set; }
    public string ie { get; set; }
    public string il { get; set; }
    public string im { get; set; }
    public string @is { get; set; }
    public string it { get; set; }
    public string je { get; set; }
    public string lb { get; set; }
    public string li { get; set; }
    public string lt { get; set; }
    public string lu { get; set; }
    public string lv { get; set; }
    public string ly { get; set; }
    public string ma { get; set; }
    public string mc { get; set; }
    public string md { get; set; }
    public string me { get; set; }
    public string mk { get; set; }
    public string mt { get; set; }
    public string nl { get; set; }
    public string no { get; set; }
    public string pl { get; set; }
    public string ps { get; set; }
    public string pt { get; set; }
    public string ro { get; set; }
    public string rs { get; set; }
    public string se { get; set; }
    public string si { get; set; }
    public string sj { get; set; }
    public string sk { get; set; }
    public string sm { get; set; }
    public string sy { get; set; }
    public string tn { get; set; }
    public string tr { get; set; }
    public string ua { get; set; }
    public string uk { get; set; }
    public string us { get; set; }
    public string va { get; set; }
    public string world { get; set; }
    public string xk { get; set; }
}

public class Images
{
    [JsonProperty("1")]
    public _1 _1 { get; set; }

    [JsonProperty("2")]
    public _2 _2 { get; set; }

    [JsonProperty("3")]
    public _3 _3 { get; set; }

    [JsonProperty("4")]
    public _4 _4 { get; set; }

    [JsonProperty("5")]
    public _5 _5 { get; set; }

    [JsonProperty("6")]
    public _6 _6 { get; set; }
    public FrontEn front_en { get; set; }
    public FrontPl front_pl { get; set; }
    public IngredientsEn ingredients_en { get; set; }
    public IngredientsPl ingredients_pl { get; set; }
    public NutritionEn nutrition_en { get; set; }
    public NutritionPl nutrition_pl { get; set; }
}

public class Ingredient
{
    public string id { get; set; }
    public int percent { get; set; }
    public double percent_estimate { get; set; }
    public double percent_max { get; set; }
    public double percent_min { get; set; }
    public int rank { get; set; }
    public string text { get; set; }
    public string vegan { get; set; }
    public string vegetarian { get; set; }
    public string has_sub_ingredients { get; set; }
    public Display display { get; set; }
    public Small small { get; set; }
    public Thumb thumb { get; set; }
}

public class IngredientsAnalysis
{
    [JsonProperty("en:non-vegan")]
    public List<string> ennonvegan { get; set; }

    [JsonProperty("en:non-vegetarian")]
    public List<string> ennonvegetarian { get; set; }

    [JsonProperty("en:palm-oil-content-unknown")]
    public List<string> enpalmoilcontentunknown { get; set; }

    [JsonProperty("en:vegan-status-unknown")]
    public List<string> enveganstatusunknown { get; set; }

    [JsonProperty("en:vegetarian-status-unknown")]
    public List<string> envegetarianstatusunknown { get; set; }
}

public class IngredientsEn
{
    public object angle { get; set; }
    public string geometry { get; set; }
    public string imgid { get; set; }
    public string normalize { get; set; }
    public string rev { get; set; }
    public Sizes sizes { get; set; }
    public string white_magic { get; set; }
    public string x1 { get; set; }
    public string x2 { get; set; }
    public string y1 { get; set; }
    public string y2 { get; set; }
}

public class IngredientsPl
{
    public object angle { get; set; }
    public string geometry { get; set; }
    public string imgid { get; set; }
    public object normalize { get; set; }
    public string rev { get; set; }
    public Sizes sizes { get; set; }
    public object white_magic { get; set; }
    public object x1 { get; set; }
    public object x2 { get; set; }
    public object y1 { get; set; }
    public object y2 { get; set; }
}

public class Languages
{
    [JsonProperty("en:english")]
    public int enenglish { get; set; }

    [JsonProperty("en:polish")]
    public int enpolish { get; set; }
}

public class LanguagesCodes
{
    public int en { get; set; }
    public int pl { get; set; }
}

public class Missing
{
    public int labels { get; set; }
    public int packagings { get; set; }
    public int? origins { get; set; }
    public int? categories { get; set; }
    public int? ingredients { get; set; }
}

public class NovaGroupsMarkers
{
    [JsonProperty("3")]
    public List<List<string>> _3 { get; set; }

    [JsonProperty("4")]
    public List<List<string>> _4 { get; set; }
}

public class NutrientLevels
{
    public string fat { get; set; }
    public string salt { get; set; }

    [JsonProperty("saturated-fat")]
    public string saturatedfat { get; set; }
    public string sugars { get; set; }
}

public class Nutriments
{
    public double carbohydrates { get; set; }
    public double carbohydrates_100g { get; set; }
    public double carbohydrates_serving { get; set; }
    public string carbohydrates_unit { get; set; }
    public double carbohydrates_value { get; set; }
    public int energy { get; set; }

    [JsonProperty("energy-kcal")]
    public int energykcal { get; set; }

    [JsonProperty("energy-kcal_100g")]
    public int energykcal_100g { get; set; }

    [JsonProperty("energy-kcal_serving")]
    public int energykcal_serving { get; set; }

    [JsonProperty("energy-kcal_unit")]
    public string energykcal_unit { get; set; }

    [JsonProperty("energy-kcal_value")]
    public int energykcal_value { get; set; }

    [JsonProperty("energy-kcal_value_computed")]
    public double energykcal_value_computed { get; set; }

    [JsonProperty("energy-kj")]
    public int energykj { get; set; }

    [JsonProperty("energy-kj_100g")]
    public int energykj_100g { get; set; }

    [JsonProperty("energy-kj_serving")]
    public int energykj_serving { get; set; }

    [JsonProperty("energy-kj_unit")]
    public string energykj_unit { get; set; }

    [JsonProperty("energy-kj_value")]
    public int energykj_value { get; set; }

    [JsonProperty("energy-kj_value_computed")]
    public double energykj_value_computed { get; set; }
    public int energy_100g { get; set; }
    public int energy_serving { get; set; }
    public string energy_unit { get; set; }
    public int energy_value { get; set; }
    public int fat { get; set; }
    public int fat_100g { get; set; }
    public double fat_serving { get; set; }
    public string fat_unit { get; set; }
    public int fat_value { get; set; }

    [JsonProperty("fruits-vegetables-nuts-estimate-from-ingredients_100g")]
    public int fruitsvegetablesnutsestimatefromingredients_100g { get; set; }

    [JsonProperty("fruits-vegetables-nuts-estimate-from-ingredients_serving")]
    public int fruitsvegetablesnutsestimatefromingredients_serving { get; set; }

    [JsonProperty("nova-group")]
    public int novagroup { get; set; }

    [JsonProperty("nova-group_100g")]
    public int novagroup_100g { get; set; }

    [JsonProperty("nova-group_serving")]
    public int novagroup_serving { get; set; }

    [JsonProperty("nutrition-score-fr")]
    public int nutritionscorefr { get; set; }

    [JsonProperty("nutrition-score-fr_100g")]
    public int nutritionscorefr_100g { get; set; }
    public int proteins { get; set; }
    public int proteins_100g { get; set; }
    public double proteins_serving { get; set; }
    public string proteins_unit { get; set; }
    public int proteins_value { get; set; }
    public double salt { get; set; }
    public double salt_100g { get; set; }
    public double salt_serving { get; set; }
    public string salt_unit { get; set; }
    public double salt_value { get; set; }

    [JsonProperty("saturated-fat")]
    public double saturatedfat { get; set; }

    [JsonProperty("saturated-fat_100g")]
    public double saturatedfat_100g { get; set; }

    [JsonProperty("saturated-fat_serving")]
    public double saturatedfat_serving { get; set; }

    [JsonProperty("saturated-fat_unit")]
    public string saturatedfat_unit { get; set; }

    [JsonProperty("saturated-fat_value")]
    public double saturatedfat_value { get; set; }
    public int sodium { get; set; }
    public int sodium_100g { get; set; }
    public double sodium_serving { get; set; }
    public string sodium_unit { get; set; }
    public int sodium_value { get; set; }
    public double sugars { get; set; }
    public double sugars_100g { get; set; }
    public double sugars_serving { get; set; }
    public string sugars_unit { get; set; }
    public double sugars_value { get; set; }
}

public class NutriscoreData
{
    public int energy { get; set; }
    public int energy_points { get; set; }
    public int energy_value { get; set; }
    public int fiber { get; set; }
    public int fiber_points { get; set; }
    public int fiber_value { get; set; }
    public int fruits_vegetables_nuts_colza_walnut_olive_oils { get; set; }
    public int fruits_vegetables_nuts_colza_walnut_olive_oils_points { get; set; }
    public int fruits_vegetables_nuts_colza_walnut_olive_oils_value { get; set; }
    public string grade { get; set; }
    public int is_beverage { get; set; }
    public int is_cheese { get; set; }
    public int is_fat { get; set; }
    public int is_water { get; set; }
    public int negative_points { get; set; }
    public int positive_points { get; set; }
    public int proteins { get; set; }
    public int proteins_points { get; set; }
    public int proteins_value { get; set; }
    public double saturated_fat { get; set; }
    public int saturated_fat_points { get; set; }
    public double saturated_fat_ratio { get; set; }
    public int saturated_fat_ratio_points { get; set; }
    public int saturated_fat_ratio_value { get; set; }
    public double saturated_fat_value { get; set; }
    public int score { get; set; }
    public int sodium { get; set; }
    public int sodium_points { get; set; }
    public int sodium_value { get; set; }
    public double sugars { get; set; }
    public int sugars_points { get; set; }
    public double sugars_value { get; set; }
}

public class Nutrition
{
    public Display display { get; set; }
    public Small small { get; set; }
    public Thumb thumb { get; set; }
}

public class NutritionEn
{
    public string angle { get; set; }
    public string geometry { get; set; }
    public string imgid { get; set; }
    public string normalize { get; set; }
    public string rev { get; set; }
    public Sizes sizes { get; set; }
    public string white_magic { get; set; }
    public string x1 { get; set; }
    public string x2 { get; set; }
    public string y1 { get; set; }
    public string y2 { get; set; }
}

public class NutritionPl
{
    public string angle { get; set; }
    public string geometry { get; set; }
    public string imgid { get; set; }
    public string normalize { get; set; }
    public string rev { get; set; }
    public Sizes sizes { get; set; }
    public string white_magic { get; set; }
    public string x1 { get; set; }
    public string x2 { get; set; }
    public string y1 { get; set; }
    public string y2 { get; set; }
}

public class OriginsOfIngredients
{
    public List<AggregatedOrigin> aggregated_origins { get; set; }
    public int epi_score { get; set; }
    public int epi_value { get; set; }
    public List<string> origins_from_origins_field { get; set; }
    public int transportation_score { get; set; }
    public TransportationScores transportation_scores { get; set; }
    public int transportation_value { get; set; }
    public TransportationValues transportation_values { get; set; }
    public int value { get; set; }
    public Values values { get; set; }
    public string warning { get; set; }
}

public class Packaging
{
    public int non_recyclable_and_non_biodegradable_materials { get; set; }
    public int value { get; set; }
    public string warning { get; set; }
    public List<Packaging> packagings { get; set; }
    public int? score { get; set; }
}

public class Packaging2
{
    public int ecoscore_material_score { get; set; }
    public int ecoscore_shape_ratio { get; set; }
    public string material { get; set; }
    public string non_recyclable_and_non_biodegradable { get; set; }
    public string shape { get; set; }
}

public class PreviousData
{
    public Agribalyse agribalyse { get; set; }
    public string grade { get; set; }
    public int score { get; set; }
}

public class Product
{
    public string _id { get; set; }
    public List<string> _keywords { get; set; }
    public List<object> added_countries_tags { get; set; }
    public List<object> additives_debug_tags { get; set; }
    public int additives_n { get; set; }
    public int additives_old_n { get; set; }
    public List<string> additives_old_tags { get; set; }
    public List<string> additives_original_tags { get; set; }
    public List<object> additives_prev_original_tags { get; set; }
    public List<string> additives_tags { get; set; }
    public string allergens { get; set; }
    public string allergens_from_ingredients { get; set; }
    public string allergens_from_user { get; set; }
    public List<string> allergens_hierarchy { get; set; }
    public string allergens_lc { get; set; }
    public List<string> allergens_tags { get; set; }
    public List<object> amino_acids_prev_tags { get; set; }
    public List<object> amino_acids_tags { get; set; }
    public string brands { get; set; }
    public List<string> brands_tags { get; set; }
    public string categories { get; set; }
    public List<string> categories_hierarchy { get; set; }
    public string categories_lc { get; set; }
    public string categories_old { get; set; }
    public CategoriesProperties categories_properties { get; set; }
    public List<string> categories_properties_tags { get; set; }
    public List<string> categories_tags { get; set; }
    public CategoryProperties category_properties { get; set; }
    public List<object> checkers_tags { get; set; }
    public List<string> ciqual_food_name_tags { get; set; }
    public List<object> cities_tags { get; set; }
    public string code { get; set; }
    public List<string> codes_tags { get; set; }
    public string compared_to_category { get; set; }
    public int complete { get; set; }
    public double completeness { get; set; }
    public List<string> correctors_tags { get; set; }
    public string countries { get; set; }
    public List<string> countries_hierarchy { get; set; }
    public string countries_lc { get; set; }
    public List<string> countries_tags { get; set; }
    public int created_t { get; set; }
    public string creator { get; set; }
    public List<object> data_quality_bugs_tags { get; set; }
    public List<object> data_quality_errors_tags { get; set; }
    public List<string> data_quality_info_tags { get; set; }
    public List<string> data_quality_tags { get; set; }
    public List<string> data_quality_warnings_tags { get; set; }
    public string data_sources { get; set; }
    public List<string> data_sources_tags { get; set; }
    public List<string> debug_param_sorted_langs { get; set; }
    public EcoscoreData ecoscore_data { get; set; }
    public string ecoscore_grade { get; set; }
    public int ecoscore_score { get; set; }
    public List<string> ecoscore_tags { get; set; }
    public List<string> editors_tags { get; set; }
    public string emb_codes { get; set; }
    public string emb_codes_20141016 { get; set; }
    public List<string> emb_codes_tags { get; set; }
    public List<string> entry_dates_tags { get; set; }
    public string expiration_date { get; set; }
    public string food_groups { get; set; }
    public List<string> food_groups_tags { get; set; }
    public string generic_name_en { get; set; }
    public string generic_name_pl { get; set; }
    public string id { get; set; }
    public string image_front_small_url { get; set; }
    public string image_front_thumb_url { get; set; }
    public string image_front_url { get; set; }
    public string image_ingredients_small_url { get; set; }
    public string image_ingredients_thumb_url { get; set; }
    public string image_ingredients_url { get; set; }
    public string image_nutrition_small_url { get; set; }
    public string image_nutrition_thumb_url { get; set; }
    public string image_nutrition_url { get; set; }
    public string image_small_url { get; set; }
    public string image_thumb_url { get; set; }
    public string image_url { get; set; }
    public Images images { get; set; }
    public List<string> informers_tags { get; set; }
    public List<Ingredient> ingredients { get; set; }
    public IngredientsAnalysis ingredients_analysis { get; set; }
    public List<string> ingredients_analysis_tags { get; set; }
    public List<object> ingredients_debug { get; set; }
    public int ingredients_from_or_that_may_be_from_palm_oil_n { get; set; }
    public int ingredients_from_palm_oil_n { get; set; }
    public List<object> ingredients_from_palm_oil_tags { get; set; }
    public List<string> ingredients_hierarchy { get; set; }
    public List<object> ingredients_ids_debug { get; set; }
    public int ingredients_n { get; set; }
    public List<string> ingredients_n_tags { get; set; }
    public List<string> ingredients_original_tags { get; set; }
    public int ingredients_percent_analysis { get; set; }
    public List<string> ingredients_tags { get; set; }
    public string ingredients_text { get; set; }
    public string ingredients_text_en { get; set; }
    public string ingredients_text_pl { get; set; }
    public string ingredients_text_with_allergens { get; set; }
    public string ingredients_text_with_allergens_en { get; set; }
    public string ingredients_text_with_allergens_pl { get; set; }
    public int ingredients_that_may_be_from_palm_oil_n { get; set; }
    public List<object> ingredients_that_may_be_from_palm_oil_tags { get; set; }
    public int ingredients_with_specified_percent_n { get; set; }
    public int ingredients_with_specified_percent_sum { get; set; }
    public int ingredients_with_unspecified_percent_n { get; set; }
    public int ingredients_with_unspecified_percent_sum { get; set; }
    public string interface_version_created { get; set; }
    public string interface_version_modified { get; set; }
    public int known_ingredients_n { get; set; }
    public string labels { get; set; }
    public List<string> labels_hierarchy { get; set; }
    public string labels_lc { get; set; }
    public string labels_old { get; set; }
    public List<string> labels_tags { get; set; }
    public string lang { get; set; }
    public Languages languages { get; set; }
    public LanguagesCodes languages_codes { get; set; }
    public List<string> languages_hierarchy { get; set; }
    public List<string> languages_tags { get; set; }
    public List<string> last_edit_dates_tags { get; set; }
    public string last_editor { get; set; }
    public List<string> last_image_dates_tags { get; set; }
    public int last_image_t { get; set; }
    public string last_modified_by { get; set; }
    public int last_modified_t { get; set; }
    public string lc { get; set; }
    public string link { get; set; }
    public List<object> main_countries_tags { get; set; }
    public string manufacturing_places { get; set; }
    public List<string> manufacturing_places_tags { get; set; }
    public string max_imgid { get; set; }
    public List<object> minerals_prev_tags { get; set; }
    public List<object> minerals_tags { get; set; }
    public List<string> misc_tags { get; set; }
    public string no_nutrition_data { get; set; }
    public int nova_group { get; set; }
    public string nova_group_debug { get; set; }
    public string nova_groups { get; set; }
    public NovaGroupsMarkers nova_groups_markers { get; set; }
    public List<string> nova_groups_tags { get; set; }
    public List<object> nucleotides_prev_tags { get; set; }
    public List<object> nucleotides_tags { get; set; }
    public NutrientLevels nutrient_levels { get; set; }
    public List<string> nutrient_levels_tags { get; set; }
    public Nutriments nutriments { get; set; }
    public NutriscoreData nutriscore_data { get; set; }
    public string nutriscore_grade { get; set; }
    public int nutriscore_score { get; set; }
    public int nutriscore_score_opposite { get; set; }
    public string nutrition_data { get; set; }
    public string nutrition_data_per { get; set; }
    public string nutrition_data_prepared { get; set; }
    public string nutrition_data_prepared_per { get; set; }
    public string nutrition_grade_fr { get; set; }
    public string nutrition_grades { get; set; }
    public List<string> nutrition_grades_tags { get; set; }
    public int nutrition_score_beverage { get; set; }
    public string nutrition_score_debug { get; set; }
    public int nutrition_score_warning_fruits_vegetables_nuts_estimate_from_ingredients { get; set; }
    public int nutrition_score_warning_fruits_vegetables_nuts_estimate_from_ingredients_value { get; set; }
    public int nutrition_score_warning_no_fiber { get; set; }
    public string obsolete { get; set; }
    public string obsolete_since_date { get; set; }
    public string origin_en { get; set; }
    public string origin_pl { get; set; }
    public string origins { get; set; }
    public List<string> origins_hierarchy { get; set; }
    public string origins_lc { get; set; }
    public string origins_old { get; set; }
    public List<string> origins_tags { get; set; }
    public List<object> other_nutritional_substances_tags { get; set; }
    public string packaging { get; set; }
    public List<string> packaging_hierarchy { get; set; }
    public string packaging_lc { get; set; }
    public string packaging_old { get; set; }
    public string packaging_old_before_taxonomization { get; set; }
    public List<string> packaging_tags { get; set; }
    public string packaging_text_en { get; set; }
    public string packaging_text_pl { get; set; }
    public List<Packaging> packagings { get; set; }
    public List<string> photographers_tags { get; set; }
    public string pnns_groups_1 { get; set; }
    public List<string> pnns_groups_1_tags { get; set; }
    public string pnns_groups_2 { get; set; }
    public List<string> pnns_groups_2_tags { get; set; }
    public object popularity_key { get; set; }
    public List<string> popularity_tags { get; set; }
    public string product_name { get; set; }
    public string product_name_en { get; set; }
    public string product_name_pl { get; set; }
    public string product_quantity { get; set; }
    public string purchase_places { get; set; }
    public List<string> purchase_places_tags { get; set; }
    public string quantity { get; set; }
    public List<object> removed_countries_tags { get; set; }
    public int rev { get; set; }
    public int scans_n { get; set; }
    public SelectedImages selected_images { get; set; }
    public string serving_quantity { get; set; }
    public string serving_size { get; set; }
    public int sortkey { get; set; }
    public string states { get; set; }
    public List<string> states_hierarchy { get; set; }
    public List<string> states_tags { get; set; }
    public string stores { get; set; }
    public List<string> stores_tags { get; set; }
    public string traces { get; set; }
    public string traces_from_ingredients { get; set; }
    public string traces_from_user { get; set; }
    public List<string> traces_hierarchy { get; set; }
    public string traces_lc { get; set; }
    public List<string> traces_tags { get; set; }
    public int unique_scans_n { get; set; }
    public int unknown_ingredients_n { get; set; }
    public List<object> unknown_nutrients_tags { get; set; }
    public string update_key { get; set; }
    public string url { get; set; }
    public List<object> vitamins_prev_tags { get; set; }
    public List<object> vitamins_tags { get; set; }
    public string nova_group_error { get; set; }
}

public class ProductionSystem
{
    public List<object> labels { get; set; }
    public int value { get; set; }
    public string warning { get; set; }
}

public class Root
{
    public int count { get; set; }
    public int page { get; set; }
    public int page_count { get; set; }
    public int page_size { get; set; }
    public List<Product> products { get; set; }
    public int skip { get; set; }
}

public class Scores
{
    public int ad { get; set; }
    public int al { get; set; }
    public int at { get; set; }
    public int ax { get; set; }
    public int ba { get; set; }
    public int be { get; set; }
    public int bg { get; set; }
    public int ch { get; set; }
    public int cy { get; set; }
    public int cz { get; set; }
    public int de { get; set; }
    public int dk { get; set; }
    public int dz { get; set; }
    public int ee { get; set; }
    public int eg { get; set; }
    public int es { get; set; }
    public int fi { get; set; }
    public int fo { get; set; }
    public int fr { get; set; }
    public int gg { get; set; }
    public int gi { get; set; }
    public int gr { get; set; }
    public int hr { get; set; }
    public int hu { get; set; }
    public int ie { get; set; }
    public int il { get; set; }
    public int im { get; set; }
    public int @is { get; set; }
    public int it { get; set; }
    public int je { get; set; }
    public int lb { get; set; }
    public int li { get; set; }
    public int lt { get; set; }
    public int lu { get; set; }
    public int lv { get; set; }
    public int ly { get; set; }
    public int ma { get; set; }
    public int mc { get; set; }
    public int md { get; set; }
    public int me { get; set; }
    public int mk { get; set; }
    public int mt { get; set; }
    public int nl { get; set; }
    public int no { get; set; }
    public int pl { get; set; }
    public int ps { get; set; }
    public int pt { get; set; }
    public int ro { get; set; }
    public int rs { get; set; }
    public int se { get; set; }
    public int si { get; set; }
    public int sj { get; set; }
    public int sk { get; set; }
    public int sm { get; set; }
    public int sy { get; set; }
    public int tn { get; set; }
    public int tr { get; set; }
    public int ua { get; set; }
    public int uk { get; set; }
    public int us { get; set; }
    public int va { get; set; }
    public int world { get; set; }
    public int xk { get; set; }
}

public class SelectedImages
{
    public Front front { get; set; }
    public Ingredient ingredients { get; set; }
    public Nutrition nutrition { get; set; }
}

public class Sizes
{
    [JsonProperty("100")]
    public _100 _100 { get; set; }

    [JsonProperty("400")]
    public _400 _400 { get; set; }
    public Full full { get; set; }

    [JsonProperty("200")]
    public _200 _200 { get; set; }
}

public class Small
{
    public string en { get; set; }
    public string pl { get; set; }
}

public class ThreatenedSpecies
{
    public string warning { get; set; }
}

public class Thumb
{
    public string en { get; set; }
    public string pl { get; set; }
}

public class TransportationScores
{
    public int ad { get; set; }
    public int al { get; set; }
    public int at { get; set; }
    public int ax { get; set; }
    public int ba { get; set; }
    public int be { get; set; }
    public int bg { get; set; }
    public int ch { get; set; }
    public int cy { get; set; }
    public int cz { get; set; }
    public int de { get; set; }
    public int dk { get; set; }
    public int dz { get; set; }
    public int ee { get; set; }
    public int eg { get; set; }
    public int es { get; set; }
    public int fi { get; set; }
    public int fo { get; set; }
    public int fr { get; set; }
    public int gg { get; set; }
    public int gi { get; set; }
    public int gr { get; set; }
    public int hr { get; set; }
    public int hu { get; set; }
    public int ie { get; set; }
    public int il { get; set; }
    public int im { get; set; }
    public int @is { get; set; }
    public int it { get; set; }
    public int je { get; set; }
    public int lb { get; set; }
    public int li { get; set; }
    public int lt { get; set; }
    public int lu { get; set; }
    public int lv { get; set; }
    public int ly { get; set; }
    public int ma { get; set; }
    public int mc { get; set; }
    public int md { get; set; }
    public int me { get; set; }
    public int mk { get; set; }
    public int mt { get; set; }
    public int nl { get; set; }
    public int no { get; set; }
    public int pl { get; set; }
    public int ps { get; set; }
    public int pt { get; set; }
    public int ro { get; set; }
    public int rs { get; set; }
    public int se { get; set; }
    public int si { get; set; }
    public int sj { get; set; }
    public int sk { get; set; }
    public int sm { get; set; }
    public int sy { get; set; }
    public int tn { get; set; }
    public int tr { get; set; }
    public int ua { get; set; }
    public int uk { get; set; }
    public int us { get; set; }
    public int va { get; set; }
    public int world { get; set; }
    public int xk { get; set; }
}

public class TransportationValues
{
    public int ad { get; set; }
    public int al { get; set; }
    public int at { get; set; }
    public int ax { get; set; }
    public int ba { get; set; }
    public int be { get; set; }
    public int bg { get; set; }
    public int ch { get; set; }
    public int cy { get; set; }
    public int cz { get; set; }
    public int de { get; set; }
    public int dk { get; set; }
    public int dz { get; set; }
    public int ee { get; set; }
    public int eg { get; set; }
    public int es { get; set; }
    public int fi { get; set; }
    public int fo { get; set; }
    public int fr { get; set; }
    public int gg { get; set; }
    public int gi { get; set; }
    public int gr { get; set; }
    public int hr { get; set; }
    public int hu { get; set; }
    public int ie { get; set; }
    public int il { get; set; }
    public int im { get; set; }
    public int @is { get; set; }
    public int it { get; set; }
    public int je { get; set; }
    public int lb { get; set; }
    public int li { get; set; }
    public int lt { get; set; }
    public int lu { get; set; }
    public int lv { get; set; }
    public int ly { get; set; }
    public int ma { get; set; }
    public int mc { get; set; }
    public int md { get; set; }
    public int me { get; set; }
    public int mk { get; set; }
    public int mt { get; set; }
    public int nl { get; set; }
    public int no { get; set; }
    public int pl { get; set; }
    public int ps { get; set; }
    public int pt { get; set; }
    public int ro { get; set; }
    public int rs { get; set; }
    public int se { get; set; }
    public int si { get; set; }
    public int sj { get; set; }
    public int sk { get; set; }
    public int sm { get; set; }
    public int sy { get; set; }
    public int tn { get; set; }
    public int tr { get; set; }
    public int ua { get; set; }
    public int uk { get; set; }
    public int us { get; set; }
    public int va { get; set; }
    public int world { get; set; }
    public int xk { get; set; }
}

public class Values
{
    public int ad { get; set; }
    public int al { get; set; }
    public int at { get; set; }
    public int ax { get; set; }
    public int ba { get; set; }
    public int be { get; set; }
    public int bg { get; set; }
    public int ch { get; set; }
    public int cy { get; set; }
    public int cz { get; set; }
    public int de { get; set; }
    public int dk { get; set; }
    public int dz { get; set; }
    public int ee { get; set; }
    public int eg { get; set; }
    public int es { get; set; }
    public int fi { get; set; }
    public int fo { get; set; }
    public int fr { get; set; }
    public int gg { get; set; }
    public int gi { get; set; }
    public int gr { get; set; }
    public int hr { get; set; }
    public int hu { get; set; }
    public int ie { get; set; }
    public int il { get; set; }
    public int im { get; set; }
    public int @is { get; set; }
    public int it { get; set; }
    public int je { get; set; }
    public int lb { get; set; }
    public int li { get; set; }
    public int lt { get; set; }
    public int lu { get; set; }
    public int lv { get; set; }
    public int ly { get; set; }
    public int ma { get; set; }
    public int mc { get; set; }
    public int md { get; set; }
    public int me { get; set; }
    public int mk { get; set; }
    public int mt { get; set; }
    public int nl { get; set; }
    public int no { get; set; }
    public int pl { get; set; }
    public int ps { get; set; }
    public int pt { get; set; }
    public int ro { get; set; }
    public int rs { get; set; }
    public int se { get; set; }
    public int si { get; set; }
    public int sj { get; set; }
    public int sk { get; set; }
    public int sm { get; set; }
    public int sy { get; set; }
    public int tn { get; set; }
    public int tr { get; set; }
    public int ua { get; set; }
    public int uk { get; set; }
    public int us { get; set; }
    public int va { get; set; }
    public int world { get; set; }
    public int xk { get; set; }
}

#pragma warning enable