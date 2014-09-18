using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class OnlineMarket
{
    const string Test001 = @"add Milk 1.90 dairy
add Yogurt 1.90 dairy
add Notebook 1111.90 technology
add Orbit 0.90 food
add Rakia 11.90 drinks
add Dress 121.90 clothes
add Jacket 49.90 clothes
add Milk 1.90 dairy
add Socks 2.90 clothes
filter by type dairy
filter by price from 1.00 to 2.00
filter by price from 1.50
filter by price to 2.00
filter by type clothes
end
";

    static readonly StringBuilder output = new StringBuilder();

    static MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(true);
    static MultiDictionary<string, Product> byType = new MultiDictionary<string, Product>(true);
    static OrderedMultiDictionary<double, Product> byPrice = new OrderedMultiDictionary<double, Product>(true);

    static void Main()
    {
        //Console.SetIn(new StringReader(Test001));

        string line = Console.ReadLine();
        while (!line.StartsWith("end"))
        {
            var commands = line.Split(' ');
            switch (commands[0])
            {
                case "add": Add(commands); break;
                case "filter":
                    if (commands[2] == "price")
                        FilterByPrice(commands);
                    else
                        FilterByType(commands);
                    break;
            }
            line = Console.ReadLine();
        }

        Console.WriteLine(output.ToString().Trim());
    }

    private static void FilterByType(string[] commands)
    {
        // filter by type PRODUCT_TYPE 
        string type = commands[3];
        if (!byType.ContainsKey(type))
        {
            PrintMessage(string.Format("Error: Type {0} does not exists", type));
            return;
        }

        PrintSortedProducts(byType[type]);
    }

    private static void FilterByPrice(string[] parameters)
    {
        // filter by price from MIN_PRICE to MAX_PRICE 
        // filter by price from MIN_PRICE 
        // filter by price to MAX_PRICE 

        double from;
        double to;
        if (parameters.Length == 7)
        {
            from = double.Parse(parameters[4]);
            to = double.Parse(parameters[6]);
        }
        else if (parameters[3] == "to")
        {
            from = double.MinValue;
            to = double.Parse(parameters[4]);
        }
        else
        {
            from = double.Parse(parameters[4]);
            to = double.MaxValue;
        }

        PrintSortedProducts(byPrice.Range(from, true, to, true).Values);
    }

    static void PrintSortedProducts(ICollection<Product> products)
    {
        if (products.Count == 0)
        {
            PrintMessage("Ok: ");
            return;
        }

        PrintMessage("Ok: " + string.Join(", ",
            products
            .OrderBy(a => a.Price)
            .ThenBy(a => a.Name)
            .ThenBy(a => a.Type)
            .Take(10)));
    }

    private static void Add(string[] parameters)
    {
        string name = parameters[1];
        if (byName.ContainsKey(name))
        {
            PrintMessage(string.Format("Error: Product {0} already exists", name));
            return;
        }

        var product = new Product(name, double.Parse(parameters[2]), parameters[3]);
        byName.Add(product.Name, product);
        byPrice.Add(product.Price, product);
        byType.Add(product.Type, product);

        PrintMessage(string.Format("Ok: Product {0} added successfully", name));
    }

    static void PrintMessage(object message)
    {
        output.AppendLine(message.ToString());
    }
}

class Product : IComparable<Product>
{
    public Product(string name, double price, string type)
    {
        this.Name = name;
        this.Price = price;
        this.Type = type;
    }

    public string Name { get; private set; }
    public double Price { get; private set; }
    public string Type { get; private set; }

    public int CompareTo(Product other)
    {
        return (int)(this.Price - other.Price);
    }

    public override string ToString()
    {
        return string.Format("{0}({1})", this.Name, this.Price);
    }
}
