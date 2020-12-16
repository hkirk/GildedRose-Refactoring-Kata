using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        public static string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        public static string BackstagePassesToATafkal80etcConcert = "Backstage passes to a TAFKAL80ETC concert";
        public static string AgedBrie = "Aged Brie";
        
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == SulfurasHandOfRagnaros)
                {
                    break;
                }

                if (Items[i].Name != AgedBrie && Items[i].Name != BackstagePassesToATafkal80etcConcert)
                {
                    Items[i].Quality -= 1;
                }
                else
                {
                    Items[i].Quality += 1;
                    (Items[i] as BackstagePassItem)?.IncreaseQuality();
                }


                Items[i].SellIn -= 1;

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AgedBrie)
                    {
                        if (Items[i].Name != BackstagePassesToATafkal80etcConcert)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                        else
                        {
                            Items[i].Quality = 0;
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }

                MaxQuality(Items[i]);
                MinQuality(Items[i]);
            }
        }

        private void MinQuality(Item item)
        {
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        private void MaxQuality(Item item)
        {
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}
