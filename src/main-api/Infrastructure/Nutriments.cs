#nullable disable
#pragma warning disable
using Newtonsoft.Json;


namespace Infrastructure;
internal class Nutriments
{

        public double carbohydrates { get; set; }
        public double carbohydrates_100g { get; set; }
        public string carbohydrates_serving { get; set; }
        public string carbohydrates_unit { get; set; }
        public double carbohydrates_value { get; set; }

        [JsonProperty("carbon-footprint-from-known-ingredients_product")]
        public double carbonfootprintfromknowningredients_product { get; set; }

        [JsonProperty("carbon-footprint-from-known-ingredients_serving")]
        public double carbonfootprintfromknowningredients_serving { get; set; }
        public int energy { get; set; }

        [JsonProperty("energy-kcal")]
        public double energykcal { get; set; }

        [JsonProperty("energy-kcal_100g")]
        public double energykcal_100g { get; set; }

        [JsonProperty("energy-kcal_serving")]
        public double energykcal_serving { get; set; }

        [JsonProperty("energy-kcal_unit")]
        public string energykcal_unit { get; set; }

        [JsonProperty("energy-kcal_value")]
        public double energykcal_value { get; set; }

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
        public double fat { get; set; }
        public double fat_100g { get; set; }
        public double fat_serving { get; set; }
        public string fat_unit { get; set; }
        public double fat_value { get; set; }
        public double fiber { get; set; }
        public double fiber_100g { get; set; }
        public double fiber_serving { get; set; }
        public string fiber_unit { get; set; }
        public double fiber_value { get; set; }

        [JsonProperty("fruits-vegetables-nuts-estimate-from-ingredients_100g")]
        public double fruitsvegetablesnutsestimatefromingredients_100g { get; set; }

        [JsonProperty("fruits-vegetables-nuts-estimate-from-ingredients_serving")]
        public double fruitsvegetablesnutsestimatefromingredients_serving { get; set; }

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
        public double polyunsaturatedfat { get; set; }

        [JsonProperty("polyunsaturated-fat_100g")]
        public double polyunsaturatedfat_100g { get; set; }

        [JsonProperty("polyunsaturated-fat_serving")]
        public string polyunsaturatedfat_serving { get; set; }

        [JsonProperty("polyunsaturated-fat_unit")]
        public string polyunsaturatedfat_unit { get; set; }

        [JsonProperty("polyunsaturated-fat_value")]
        public double polyunsaturatedfat_value { get; set; }
        public double proteins { get; set; }
        public double proteins_100g { get; set; }
        public double proteins_serving { get; set; }
        public string proteins_unit { get; set; }
        public double proteins_value { get; set; }
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
        public double sodium { get; set; }
        public double sodium_100g { get; set; }
        public string sodium_serving { get; set; }
        public string sodium_unit { get; set; }
        public double sodium_value { get; set; }
        public double sugars { get; set; }
        public double sugars_100g { get; set; }
        public double sugars_serving { get; set; }
        public string sugars_unit { get; set; }
        public double sugars_value { get; set; }

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
#pragma warning enable