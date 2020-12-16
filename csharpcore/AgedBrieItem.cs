namespace csharpcore
{
    public class AgedBrieItem : Item
    {
        public void IncreaseQuality()
        {
            if (SellIn < 0)
            {
                Quality += 1;
            }
        }
    }
}