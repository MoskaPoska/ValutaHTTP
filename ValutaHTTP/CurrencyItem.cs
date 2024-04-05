using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ValutaHTTP
{
    internal class CurrencyItem
    {
        [JsonPropertyName("ccy")]
        public string Ccy { get; set; }
        [JsonPropertyName("base_ccy")]
        public string Base_ccy { get; set; }
        [JsonPropertyName("buy")]
        public string Buy { get; set; }
        [JsonPropertyName("sale")]
        public string Sale { get; set; }
        [JsonIgnore]
        public string Description => $"Курсі купівлі{Buy} | Курс продажу{Sale}";
    }
}
