#nullable disable
using Newtonsoft.Json;


namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
[JsonObject()]
internal class IngredientData
{
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "rank")]
        public int? Rank { get; set; }
        [JsonProperty(PropertyName = "percent")]
        public float? Percent { get; set; }
}

#nullable enable
