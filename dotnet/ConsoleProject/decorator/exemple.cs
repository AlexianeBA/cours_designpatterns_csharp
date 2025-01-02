public interface ICafe
{
    double GetCost();
    string GetDescription();
}

public class CafeSimple : ICafe
{
    public double GetCost() => 2.0;
    public string GetDescription() => "Café simple";
}

public abstract class CafeDecorator : ICafe
{
    protected ICafe cafe;

    public CafeDecorator(ICafe cafe)
    {
        this.cafe = cafe;
    }

    public virtual double GetCost() => cafe.GetCost();
    public virtual string GetDescription() => cafe.GetDescription();
}

public class Lait : CafeDecorator
{
    public Lait(ICafe cafe) : base(cafe) { }

    public override double GetCost() => base.GetCost() + 0.5;
    public override string GetDescription() => base.GetDescription() + " + lait";
}

public class Sucre : CafeDecorator
{
    public Sucre(ICafe cafe) : base(cafe) { }

    public override double GetCost() => base.GetCost() + 0.2;
    public override string GetDescription() => base.GetDescription() + " + sucre";
}

// Utilisation
ICafe monCafe = new CafeSimple();
monCafe = new Lait(monCafe);
monCafe = new Sucre(monCafe);


// Le code utilise le pattern Decorator pour ajouter dynamiquementdes des fonctionnalités supplémentaires (lait et sucre) à un objet (ICafe) sans modifier son interface. 
// Les classes Lait et Sucre héritent de CafeDecorator et ajoutent leurs propres coût et description au café de base.