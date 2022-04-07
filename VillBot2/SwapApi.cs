using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Leaf.xNet;
using Newtonsoft.Json;
using VillBot2.blyad;


///waxpeer

namespace VillBot2
{
    class SwapApi
    {
        private string _apiKey;
        
        private const string _apiUrl = "https://waxpeer.com/"; 
        public SwapApi(string apiKey) 
        {
            _apiKey = apiKey;
        }

        public List<Item> GetItems(int minPrise, int maxPrise)
        {
            using (var request = new HttpRequest())
            {

                request.AddHeader("Authorization", _apiKey);
                request.AddHeader("Content-type", "application/json");
                bool fl = false;
                for (; fl == false;)
                {
                    try
                    {
                        var responseStr = request.Get("https://waxpeer.com/api/data/get-items-list/?skip=0&sort=best_deals&game=csgo&all=0&exact=0&min_price=" + minPrise + "&max_price=" + maxPrise).ToString();
                        var response = JsonConvert.DeserializeObject<GetItrmsResponse>(responseStr);
                        fl = true;
                        return response.Items;
                    }
                    catch
                    {

                    }
                    fl = false;
                }


                return null;


            }

        }
        
        public List<Item> Buy(long id, int prisee)
        {
            using (var request = new HttpRequest())
            {
                request.AddHeader("Authorization", _apiKey);
                request.AddHeader("Content-type", "application/json");

                var IdsSrt = JsonConvert.SerializeObject(id);

                var priseeSrt = JsonConvert.SerializeObject(prisee);


                    var test = request.Get("https://api.waxpeer.com/v1/buy-one-p2p?api=57f5f6b8489a8e3635519502e4c46a63436d54bddf45255cbd5ad7719434a397&item_id=" + id + "&token=Dqy5tD3a&partner=1187982355&price=" + prisee).ToString();
                

                return null;

            }

        }


    }


}

