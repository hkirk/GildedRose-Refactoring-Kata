namespace csharpcore
{
    public class BackstagePassItem : Item
    {
        public void IncreaseQuality()
        {
            if (SellIn < 10)
            {
                Quality += 1;
            }

            if (SellIn < 5)
            {
                Quality += 1;
            }
        }
    }
}