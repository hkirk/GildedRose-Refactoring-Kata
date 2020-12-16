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
                if (Items[i] is SulfurasHandOfRagnarosItem)
                {
                    break;
                }

                Items[i].SellIn -= 1;
                UpdatedQuality(Items[i]);
                MaxQuality(Items[i]);
                MinQuality(Items[i]);
            }
        }

        private void UpdatedQuality(Item item)
        {
            if (item is AgedItem)
            {
                item.Quality += 1;
                (item as BackstagePassItem)?.IncreaseQuality();
                (item as AgedBrieItem)?.IncreaseQuality();
            }
            else
            {
                item.Quality -= 1;
                if (item.SellIn < 0)
                {
                    item.Quality -= 1;
                }
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
