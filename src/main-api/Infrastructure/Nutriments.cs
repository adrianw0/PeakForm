#nullable disable
using Newtonsoft.Json;


namespace Infrastructure;
internal class Nutriments
{

        public decimal carbohydrates { get; set; }
        public decimal carbohydrates_100g { get; set; }
        public string carbohydrates_serving { get; set; }
        public string carbohydrates_unit { get; set; }
        public decimal carbohydrates_value { get; set; }

        [JsonProperty("carbon-footprint-from-known-ingredients_product")]
        public decimal carbonfootprintfromknowningredients_product { get; set; }

        [JsonProperty("carbon-footprint-from-known-ingredients_serving")]
        public decimal carbonfootprintfromknowningredients_serving { get; set; }
        public int energy { get; set; }

        [JsonProperty("energy-kcal")]
        public decimal energykcal { get; set; }

        [JsonProperty("energy-kcal_100g")]
        public decimal energykcal_100g { get; set; }

        [JsonProperty("energy-kcal_serving")]
        public decimal energykcal_serving { get; set; }

        [JsonProperty("energy-kcal_unit")]
        public string energykcal_unit { get; set; }

        [JsonProperty("energy-kcal_value")]
        public decimal energykcal_value { get; set; }

        [JsonProperty("energy-kcal_value_computed")]
        public decimal energykcal_value_computed { get; set; }

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
        public decimal energykj_value_computed { get; set; }
        public int energy_100g { get; set; }
        public int energy_serving { get; set; }
        public string energy_unit { get; set; }
        public int energy_value { get; set; }
        public decimal fat { get; set; }
        public decimal fat_100g { get; set; }
        public decimal fat_serving { get; set; }
        public string fat_unit { get; set; }
        public decimal fat_value { get; set; }
        public decimal fiber { get; set; }
        public decimal fiber_100g { get; set; }
        public decimal fiber_serving { get; set; }
        public string fiber_unit { get; set; }
        public decimal fiber_value { get; set; }

        [JsonProperty("fruits-vegetables-nuts-estimate-from-ingredients_100g")]
        public decimal fruitsvegetablesnutsestimatefromingredients_100g { get; set; }

        [JsonProperty("fruits-vegetables-nuts-estimate-from-ingredients_serving")]
        public decimal fruitsvegetablesnutsestimatefromingredients_serving { get; set; }

        [JsonProperty("monounsaturated-fat")]
        public string monounsaturatedfat { get; set; }

        [JsonProperty("monounsaturated-fat_100g")]
        public string monounsaturatedfat_100g { get; set; }

        [JsonProperty("monounsaturated-fat_serving")]
        public string monounsaturatedfat_serving { get; set; }

        [JsonProperty("monounsaturated-fat_unit")]
        public string monounsaturatedfat_unit { get; set; }

        [JsonProperty("monounsaturated-fat_value")]
        public string monounsaturatedfat_value { get; set; }

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

        [JsonProperty("polyunsaturated-fat")]
        public decimal polyunsaturatedfat { get; set; }

        [JsonProperty("polyunsaturated-fat_100g")]
        public decimal polyunsaturatedfat_100g { get; set; }

        [JsonProperty("polyunsaturated-fat_serving")]
        public string polyunsaturatedfat_serving { get; set; }

        [JsonProperty("polyunsaturated-fat_unit")]
        public string polyunsaturatedfat_unit { get; set; }

        [JsonProperty("polyunsaturated-fat_value")]
        public decimal polyunsaturatedfat_value { get; set; }
        public decimal proteins { get; set; }
        public decimal proteins_100g { get; set; }
        public decimal proteins_serving { get; set; }
        public string proteins_unit { get; set; }
        public decimal proteins_value { get; set; }
        public decimal salt { get; set; }
        public decimal salt_100g { get; set; }
        public decimal salt_serving { get; set; }
        public string salt_unit { get; set; }
        public decimal salt_value { get; set; }

        [JsonProperty("saturated-fat")]
        public decimal saturatedfat { get; set; }

        [JsonProperty("saturated-fat_100g")]
        public decimal saturatedfat_100g { get; set; }

        [JsonProperty("saturated-fat_serving")]
        public decimal saturatedfat_serving { get; set; }

        [JsonProperty("saturated-fat_unit")]
        public string saturatedfat_unit { get; set; }

        [JsonProperty("saturated-fat_value")]
        public decimal saturatedfat_value { get; set; }
        public decimal sodium { get; set; }
        public decimal sodium_100g { get; set; }
        public string sodium_serving { get; set; }
        public string sodium_unit { get; set; }
        public decimal sodium_value { get; set; }
        public decimal sugars { get; set; }
        public decimal sugars_100g { get; set; }
        public decimal sugars_serving { get; set; }
        public string sugars_unit { get; set; }
        public decimal sugars_value { get; set; }

        [JsonProperty("carbon-footprint-from-known-ingredients_100g")]
        public string carbonfootprintfromknowningredients_100g { get; set; }

        [JsonProperty("carbon-footprint-from-meat-or-fish_100g")]
        public string carbonfootprintfrommeatorfish_100g { get; set; }

        [JsonProperty("carbon-footprint-from-meat-or-fish_product")]
        public int? carbonfootprintfrommeatorfish_product { get; set; }

        [JsonProperty("carbon-footprint-from-meat-or-fish_serving")]
        public int? carbonfootprintfrommeatorfish_serving { get; set; }
        public string fiber_modifier { get; set; }

        [JsonProperty("monounsaturated-fat_label")]
        public string monounsaturatedfat_label { get; set; }

        [JsonProperty("polyunsaturated-fat_label")]
        public string polyunsaturatedfat_label { get; set; }
        public string starch { get; set; }
        public string starch_100g { get; set; }
        public string starch_label { get; set; }
        public string starch_serving { get; set; }
        public string starch_unit { get; set; }
        public string starch_value { get; set; }
        public string sugars_modifier { get; set; }
        public string calcium { get; set; }
        public string calcium_100g { get; set; }
        public string calcium_label { get; set; }
        public string calcium_serving { get; set; }
        public string calcium_unit { get; set; }
        public int? calcium_value { get; set; }
    
}
#nullable enable