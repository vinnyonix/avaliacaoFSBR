using Newtonsoft.Json;

namespace AvaliacaoMVCValnei.App.Utils.Http.Models
{
    public class Localidade
    {
        [JsonProperty("regiao-imediata-id")]
        public int ImmediateRegionId { get; set; }

        [JsonProperty("regiao-imediata-nome")]
        public string? ImmediateRegionName { get; set; }

        [JsonProperty("regiao-intermediaria-id")]
        public int IntermediaryRegionId { get; set; }

        [JsonProperty("regiao-intermediaria-nome")]
        public string? IntermediaryRegionName { get; set; }

        [JsonProperty("UF-id")]
        public int FederativeUnitId { get; set; }

        [JsonProperty("UF-sigla")]
        public string? FederativeUnitAcronym { get; set; }

        [JsonProperty("UF-nome")]
        public string? FederativeUnitName { get; set; }

        [JsonProperty("regiao-id")]
        public int RegionId { get; set; }

        [JsonProperty("regiao-sigla")]
        public string? RegionAcronym { get; set; }

        [JsonProperty("regiao-nome")]
        public string? RegionName { get; set; }

        public string? Exibition { get { return string.Format("{0} - {1}", FederativeUnitAcronym, ImmediateRegionName); } }
    }
}
