public class Hero
{
    public Hero(string name)
    {
        this.Name = name;
        this.Experience = 0;
        this.Weapon = new Axe(10, 10);
    }

    public string Name { get; }

    public int Experience { get; private set; }

    public Axe Weapon { get; }

    public void Attack(Dummy target)
    {
        this.Weapon.Attack(target);

        if (target.IsDead())
        {
            this.Experience += target.GiveExperience();
        }
    }
}
