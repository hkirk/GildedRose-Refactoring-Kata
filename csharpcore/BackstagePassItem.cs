namespace csharpcore
{
    public class BackstagePassItem : Item
    {
        public void IncreaseQuality()
        {
            if (SellIn < 11)
            {
                Quality += 1;
            }

            if (SellIn < 6)
            {
                Quality += 1;
            }
        }
    }
}