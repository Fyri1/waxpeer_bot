using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VillBot2
{
    public class SteamApisBase
    {
        private readonly string _apiKey;
        public Dictionary<string, SteamApisItem> Items = new Dictionary<string, SteamApisItem>();
        public SteamApisBase(string apiKey)
        {
            _apiKey = apiKey;
        }
        public void Start(TimeSpan timeout)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var resp = UpdateAllItems(_apiKey, "730");
                    if (resp != null)
                    {
                        var dict = new Dictionary<string, SteamApisItem>();
                        foreach (var item in resp.Items)
                            dict.Add(item.MarketHashName, item);
                        lock (Items)
                            Items = dict;
                    }

                    Thread.Sleep(timeout);
                }
            });

        }

        public SteamApisItemsResponse UpdateAllItems(string apiKey, string appId)
        {
            try
            {
                using (var client = new HttpRequest())
                {
                    var json = client.Get($@"https://api.steamapis.com/market/items/{appId}?api_key={apiKey}").ToString();
                    return JsonConvert.DeserializeObject<SteamApisItemsResponse>(json);
                }
            }
            catch
            {
                return null;
            }

        }
    }

    public class SteamApisItem
    {
        [JsonProperty("updated_at")]
        public ulong UpdatedAtUnix;

        [JsonProperty("prices")]
        public PricesModel Prices;

        [JsonProperty("image")]
        public string Image;

        [JsonProperty("border_color")]
        public string BorderColor;

        [JsonProperty("market_hash_name")]
        public string MarketHashName;

        [JsonProperty("market_name")]
        public string MarketName;

        [JsonProperty("nameID")]
        public string NameId;






        public class PricesModel
        {
            [JsonProperty("unstable")]
            public bool Unstable;

            [JsonProperty("unstable_reason")]
            public UnstableReason UnstableReason;

            [JsonProperty("safe")]
            public double? Safe;

            [JsonProperty("median")]
            public double? Median;

            [JsonProperty("mean")]
            public double? Mean;

            [JsonProperty("max")]
            public double? Max;

            [JsonProperty("avg")]
            public double? Avg;

            [JsonProperty("min")]
            public double? Min;

            [JsonProperty("latest")]
            public double? Latest;

            [JsonProperty("sold")]
            public Sold Sold;

            [JsonProperty("safe_ts")]
            public SafeTs SafeTs;



        }
        public enum UnstableReason
        {
            [EnumMember(Value = "LOW_SALES_WEEK")]
            LowSalesWeek,
            [EnumMember(Value = "LOW_SALES_MONTH")]
            LowSalesMonth,
            [EnumMember(Value = "LOW_SALES_3PLUS_MONTHS")]
            LowSales3months,
            [EnumMember(Value = "NO_SALES_3PLUS_MONTHS")]
            NoSales3months,
            [EnumMember(Value = "LOW_SALES_OVERALL")]
            Overall
        }
        public class Sold : SafeTs
        {
            [JsonProperty("avg_daily_volume")]
            public int? AverageDailyVolume;
        }


        public class SafeTs
        {
            [JsonProperty("last_90d")]
            public double? Last90D;
            [JsonProperty("last_30d")]
            public double? Last30D;
            [JsonProperty("last_7d")]
            public double? Last7D;
            [JsonProperty("last_24h")]
            public double? Last24H;
        }
    }

    public class SteamApisItemsResponse
    {
        [JsonProperty("appID")]
        public int? AppId;

        [JsonProperty("part")]
        public int? Part;

        [JsonProperty("__v")]
        public int? V;

        [JsonProperty("createdAt")]
        public DateTime CreatedAt;

        [JsonProperty("data")]
        public List<SteamApisItem> Items;
    }



}
