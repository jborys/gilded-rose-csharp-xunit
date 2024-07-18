using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items) UpdateItemQuality(item);
    }

    private void UpdateItemQuality(Item item)
    {
        switch (item.Name)
        {
            case "Aged Brie":
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
                else
                {
                    if (item.Quality > 0)
                        item.Quality -= 1;
                }

                item.SellIn -= 1;

                if (item.SellIn < 0 && item.Quality < 50)
                {
                    item.Quality += 1;
                }

                break;
            }
            case "Backstage passes to a TAFKAL80ETC concert":
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                    if (item.SellIn < 11)
                        if (item.Quality < 50)
                            item.Quality += 1;

                    if (item.SellIn < 6)
                        if (item.Quality < 50)
                            item.Quality += 1;
                }

                item.SellIn -= 1;

                if (item.SellIn < 0)
                    item.Quality = 0;
                break;
            }
            case "Sulfuras, Hand of Ragnaros":
                break;
            default:
            {
                if (item.Quality > 0)
                    item.Quality -= 1;

                item.SellIn -= 1;

                if (item.SellIn < 0 && item.Quality > 0)
                {
                    item.Quality -= 1;
                }

                break;
            }
        }
    }
}