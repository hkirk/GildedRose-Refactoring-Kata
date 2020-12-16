﻿using System.Collections.Generic;

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
                
                if (Items[i].Name != AgedBrie && Items[i].Name != BackstagePassesToATafkal80etcConcert)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != SulfurasHandOfRagnaros)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BackstagePassesToATafkal80etcConcert)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != SulfurasHandOfRagnaros)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AgedBrie)
                    {
                        if (Items[i].Name != BackstagePassesToATafkal80etcConcert)
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != SulfurasHandOfRagnaros)
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
