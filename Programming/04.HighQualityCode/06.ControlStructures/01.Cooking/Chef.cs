using System;

public class Chef
{
    public void Cook()
    {
        IVegetable potato = this.GetPotato();
        IVegetable carrot = this.GetCarrot();
        Bowl bowl;
        this.Peel(potato);

        this.Peel(carrot);
        bowl = this.GetBowl();

        this.Cut(potato);
        this.Cut(carrot);

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

    private void Cut(IVegetable vegetable)
    {
    }

    private void Peel(IVegetable potato)
    {
        throw new NotImplementedException();
    }

    private Potato GetPotato()
    {
        return new Potato();
    }
}