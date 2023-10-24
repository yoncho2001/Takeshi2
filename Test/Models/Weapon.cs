namespace Takeshi.Models;

public class Weapon
{
    private int id;
    private string name;
    private int damagePoints;
    private HeroClassType heroClassType;

    public Weapon()
    {
        this.name = "Default";
        this.damagePoints = 0;
        this.heroClassType = HeroClassType.Mele;
    }

    public Weapon(int id, string? name, int damagePoints, HeroClassType heroClassType)
    {
        Validate.isString(name);

        this.id = id;
        this.name = name;
        this.damagePoints = damagePoints;
        this.heroClassType = heroClassType;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public int DamagePoints
    {
        get
        {
            return this.damagePoints;
        }
    }

    public int Id
    {
        get
        {
            return this.id;
        }
    }

    public HeroClassType HeroClassType
    {
        get
        {
            return this.heroClassType;
        }
    }

    public override string ToString()
    {
        string output = Name + " " + DamagePoints.ToString() + " " + HeroClassType;
        return output;
    }
}

