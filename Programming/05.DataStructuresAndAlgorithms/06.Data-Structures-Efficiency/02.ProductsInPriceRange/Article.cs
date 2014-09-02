using System;
using System.Collections.Generic;

// A container class for the articles, no data validation
public class Article : IComparable<Article>
{
    public Article(decimal price, string title)
    {
        this.Price = price;
        this.Title = title;
    }

    public string Barcode { get; set; }

    public string Vendor { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        return string.Format("Title: {0, -9}, Price: {1:C2}", this.Title, this.Price);
    }

    public int CompareTo(Article other)
    {
        return Comparer<decimal>.Default.Compare(this.Price, other.Price);
    }
}