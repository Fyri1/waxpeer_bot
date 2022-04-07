using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VillBot2.blyad
{
    class GetItrmsResponse
    {
        [JsonProperty("items")]
        public List<Item> Items;
    }
}
