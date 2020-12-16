﻿using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        public static string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        public static string BackstagePassesToATafkal80etcConcert = "Backstage passes to a TAFKAL80ETC concert";
        public static string AgedBrie = "Aged Brie";

        private readonly IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                if (item is SulfurasHandOfRagnarosItem)
                {
                    break;
                }

                item.SellIn -= 1;
                UpdatedQuality(item);
                MaxQuality(item);
                MinQuality(item);
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
