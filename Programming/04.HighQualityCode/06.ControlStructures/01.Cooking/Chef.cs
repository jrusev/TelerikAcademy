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
        return new Bowl();
    }

    private Carrot GetCarrot()
    {
        return new Carrot();
    }

    private void Cut(Vegetable vegetable)
    {
    }

    private void Peel(Vegetable potato)
    {
        throw new NotImplementedException();
    }

    private Potato GetPotato()
    {
        return new Potato();
    }
}