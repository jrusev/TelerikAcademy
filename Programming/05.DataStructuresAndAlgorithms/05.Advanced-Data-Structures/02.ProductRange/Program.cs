using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

// Write a program to read a large collection of products (name + price)
// and efficiently find the first 20 products in the price range [a…b].
// Test for 500 000 products and 10 000 price searches.
public class Program
{
    private static readonly Random Rand = new Random();

    private static void Main()
    {
        int numProducts = 500000;
        var minPrice = 0.01;
        var maxPrice = 99999.99;
        Console.WriteLine("Generating {0} products...", numProducts);
        var products = GenerateProducts(numProducts, minPrice, maxPrice);

        DemoSearch(products);

        // Test product search
        int count = 20;
        int numSearches = 10000;
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < numSearches; i++)
        {
            var fromPrice = RandomPrice(minPrice, maxPrice);
            var toPrice = RandomPrice((double)fromPrice, maxPrice);
            GetProductsInRange(products, fromPrice, toPrice, count);
        }
        sw.Stop();
        Console.WriteLine(
            "{0} searches in {1} products done in {2} milliseconds.",
            numSearches,
            numProducts,
            sw.ElapsedMilliseconds);
    }

    private static void DemoSearch(OrderedBag<Product> products)
    {
        var fromPrice = 10.00m;
        var toPrice = 15.00m;
        var count = 20;
        var range = GetProductsInRange(products, fromPrice, toPrice, count);
        Console.WriteLine("First {0} products in the range [{1:C2}; {2:C2}]", count, fromPrice, toPrice);
        Console.WriteLine(string.Join(Environment.NewLine, range));
    }

    private static IEnumerable<Product> GetProductsInRange(
        OrderedBag<Product> products, decimal fromPrice, decimal toPrice, int count)
    {
        var range = products.Range(new Product("", fromPrice), true, new Product("", toPrice), true).Take(count);
        return range;
    }

    private static OrderedBag<Product> GenerateProducts(int numProducts, double minPrice, double maxPrice)
    {
        var products = new OrderedBag<Product>();
        for (int i = 0; i < numProducts; i++)
        {
            var randomPrice = RandomPrice(minPrice, maxPrice);
            products.Add(new Product("p" + i, randomPrice));
        }

        return products;
    }

    private static decimal RandomPrice(double minPrice, double maxPrice)
    {
        var randomDouble = (Rand.NextDouble() * (maxPrice - minPrice)) + minPrice;
        var randomPrice = (decimal)Math.Round(randomDouble, 2);
        return randomPrice;
    }
}
