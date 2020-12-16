namespace csharpcore
{
    public class AgedBrieItem : AgedItem
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