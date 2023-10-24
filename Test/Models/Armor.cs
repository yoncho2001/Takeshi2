using System.ComponentModel.DataAnnotations;
using Takeshi;
using Takeshi.Models;

namespace Test.Models;

public class Armor
{
    private int id;
    private string name;
    private int armorPoints;
    private List<Potion> potionSlots;

    public Armor(int id,string? name, int armorPoints)
    {
        Validate.isString(name);

        this.id = id;
        this.name = name;
        this.armorPoints = armorPoints;
        this.potionSlots = new List<Potion>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public int ArmorPoints
    {
        get
        {
            return this.armorPoints;
        }
    }

    public int Id
    {
        get
        {
            return this.id;
        }
    }

    public List<Potion> PotionSlots
    {
        get
        {
            return this.potionSlots;
        }
    }

    public void equipPotion(Potion potion)
    {
        Validate.isNull(potion);
        potionSlots.Add(potion);
    }

    public void usePotion(Potion potion)
    {
        Validate.isNull(potion);
        potionSlots.Remove(potion);
    }

    public override string ToString()
    {
        string output = Name + " " + ArmorPoints.ToString() + "\n";

        for (int i = 0; i < PotionSlots.Count; i++)
        {
            output += PotionSlots[i] + " ";
        }

        return output;
    }
}
