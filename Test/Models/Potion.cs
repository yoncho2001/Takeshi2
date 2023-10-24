namespace Takeshi.Models
{
    public class Potion
    {
        private int id;
        private string? name;
        private HeroField affectingField;
        private int affectingValue;

        public Potion()
        {
            this.name = "Empty";
            this.affectingField = HeroField.HealthPoints;
            this.affectingValue = 0;
        }

        public Potion(int id, string? name, HeroField affectingField, int affectingValue)
        {
            Validate.isString(name);

            this.id = id;
            this.name = name;
            this.affectingField = affectingField;
            this.affectingValue = affectingValue;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public HeroField АffectingField
        {
            get
            {
                return this.affectingField;
            }
        }

        public int АffectingValue
        {
            get
            {
                return this.affectingValue;
            }
        }

        public override string ToString()
        {
            string output = Name + " " + АffectingField + " " + АffectingValue.ToString();
            return output;
        }
    }
}
