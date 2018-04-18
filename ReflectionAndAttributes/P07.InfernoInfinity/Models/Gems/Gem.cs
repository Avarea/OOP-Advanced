public class Gem : IGem
{
    public Gem(string name, Clarity clarity)
    {
        this.Name = name;
        this.Clarity = clarity;
        this.Agility = 0;
        this.Strength = 0;
        this.Vitality = 0;
    }

    public int Strength { get; protected set; }
    public int Agility { get; protected set; }
    public int Vitality { get; protected set; }
    public string Name { get; protected set; }
    public Clarity Clarity { get; protected set; }

    protected void IncreaseStats()
    {
        this.Strength += (int) this.Clarity;
        this.Vitality += (int) this.Clarity;
        this.Agility += (int) this.Clarity;
    }
}

