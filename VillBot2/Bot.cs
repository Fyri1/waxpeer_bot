using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VillBot2.blyad;

namespace VillBot2
{
    class Bot
    {
        private SwapApi _swapApi;
        private SteamApisBase _steamApi;


        public Bot(string apiKeySwap, string apiKeySteam)
        {

            _steamApi = new SteamApisBase(apiKeySteam);
            _swapApi = new SwapApi(apiKeySwap);
            _steamApi.Start(TimeSpan.FromSeconds(200));


        }



        public void Start(int minPrice, int maxPrice, int margin, int timeout)
        {


            Task.Run(() =>
            {
                while (true)
                {
                    var items = _swapApi.GetItems(minPrice, maxPrice);
                    foreach (var item in items)
                    {
                        var swapPrice2 = (int)(item.prise);

                        var swapPrice = (int)(item.prise/10);
                       
                        if (!_steamApi.Items.ContainsKey(item.Name))
                        {
                            continue;
                        }
                        if (_steamApi.Items[item.Name].Prices.UnstableReason == SteamApisItem.UnstableReason.LowSales3months || _steamApi.Items[item.Name].Prices.UnstableReason == SteamApisItem.UnstableReason.NoSales3months)
                            continue;
                        var steamPrice = (int)(_steamApi.Items[item.Name].Prices.Safe * 100);
                       // kokon.Add(item);
                        if (steamPrice == 0)
                            continue;
                        if (swapPrice == 0)
                            continue;
                         var marginItem = (1.0 - ((double)swapPrice / (double)steamPrice)) * 100.0; // пиздует расчет маржи 
                        

                        if (marginItem >= margin)
                        {
                           
                            _swapApi.Buy(item.id, swapPrice2);
                           


                        }
                        Thread.Sleep(timeout);



                    }

                }
            });
        }

    }
}
