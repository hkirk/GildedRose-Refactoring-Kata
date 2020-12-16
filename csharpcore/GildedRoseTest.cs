using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void decreaseQualityOfFoo()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "foo", SellIn = 1, Quality = 2}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void decreaseQualityOfFooWithZeroSellIn()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 2}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void sulfurasDoNotChangeQuality()
        {
            IList<Item> Items = new List<Item>
            {
                new SulfurasHandOfRagnarosItem
                    {Name = GildedRose.SulfurasHandOfRagnaros, SellIn = 0, Quality = 2}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void increaseQualityOfAgedBrie()
        {
            IList<Item> Items = new List<Item>
            {
                new AgedBrieItem
                    {Name = GildedRose.AgedBrie, SellIn = 1, Quality = 2}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void inceaseValueOfAgedBrieWithZeroSellIn()
        {
            IList<Item> Items = new List<Item>
            {
                new AgedBrieItem
                    {Name = GildedRose.AgedBrie, SellIn = 0, Quality = 2}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(4, Items[0].Quality);
        }
        
        [Fact]
        public void maxValueOfOldBrieIs50()
        {
            IList<Item> Items = new List<Item>
            {
                new AgedBrieItem
                    {Name = GildedRose.AgedBrie, SellIn = 0, Quality = 49}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void increaseValueOfBackstagePasses()
        {
            IList<Item> Items = new List<Item>
            {
                new BackstagePassItem
                    {Name = GildedRose.BackstagePassesToATafkal80etcConcert, SellIn = 11, Quality = 2}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void increaseValueOfBackstagePasses10SellIn()
        {
            IList<Item> Items = new List<Item>
            {
                new BackstagePassItem
                    {Name = GildedRose.BackstagePassesToATafkal80etcConcert, SellIn = 10, Quality = 2}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(4, Items[0].Quality);
        }

        [Fact]
        public void increaseValueOfBackstagePasses5SellIn()
        {
            IList<Item> Items = new List<Item>
            {
                new BackstagePassItem
                    {Name = GildedRose.BackstagePassesToATafkal80etcConcert, SellIn = 5, Quality = 2}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(5, Items[0].Quality);
        }
        
        [Fact]
        public void maxValueOfBackstagePassesIs50()
        {
            IList<Item> Items = new List<Item>
            {
                new BackstagePassItem
                    {Name = GildedRose.BackstagePassesToATafkal80etcConcert, SellIn = 5, Quality = 49}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQualityZeroWhenSellInIsPassed() {

            IList<Item> Items = new List<Item>
            {
                new BackstagePassItem
                    {Name = GildedRose.BackstagePassesToATafkal80etcConcert, SellIn = 0, Quality = 20}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void SellInDecreases()
        {
            IList<Item> Items = new List<Item>
            {
                new BackstagePassItem
                    {Name = GildedRose.BackstagePassesToATafkal80etcConcert, SellIn = 0, Quality = 20}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(-1, Items[0].SellIn);
        }
        
        [Fact]
        public void SellInIgnoreForSulfuras()
        {
            IList<Item> Items = new List<Item>
            {
                new SulfurasHandOfRagnarosItem
                    {Name = GildedRose.SulfurasHandOfRagnaros, SellIn = 10, Quality = 20}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(10, Items[0].SellIn);
        }

    }
}