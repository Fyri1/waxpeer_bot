using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VillBot2.blyad
{
    class Item
    {
        [JsonProperty("name")]// ищим атребут с названием САМОГО ТОВАРА 
        public string Name;

        [JsonProperty("price")] //цену хуену 
        public float prise;

        [JsonProperty("item_id")] //айди паца 
        public long id;



        public double marginItem;

    }
   
}
