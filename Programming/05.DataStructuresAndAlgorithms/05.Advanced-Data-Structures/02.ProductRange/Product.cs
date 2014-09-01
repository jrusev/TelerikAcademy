using System;
using System.Collections.Generic;

public class Product : IComparable<Product>
{
    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int CompareTo(Product other)
    {
        return Comparer<decimal>.Default.Compare(this.Price, other.Price);
    }

    public override string ToString()
    {
        return string.Format("Product: {0,-7} | price: {1:C2}", this.Name, this.Price);
    }
}