using System;

public class Chef
{
    public void Cook()
    {
        Vegetable potato = this.GetPotato();
        this.Peel(potato);
        this.Cut(potato);

        Vegetable carrot = this.GetCarrot();        
        this.Peel(carrot);        
        this.Cut(carrot);

        var bowl = this.GetBowl();
        bowl.Add(carrot);
        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        Console.WriteLine("Get bowl");
        return new Bowl();
    }

    private Carrot GetCarrot()
    {
        Console.WriteLine("Get carrot");
        return new Carrot();
    }

    private void Cut(Vegetable vegetable)
    {
        Console.WriteLine("Cut {0}", vegetable);
    }

    private void Peel(Vegetable vegetable)
    {
        Console.WriteLine("Peel {0}", vegetable);
    }

    private Potato GetPotato()
    {
        Console.WriteLine("Get potato");
        return new Potato();
    }
}