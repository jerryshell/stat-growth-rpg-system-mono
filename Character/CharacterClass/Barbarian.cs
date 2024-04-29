public class Barbarian : CharacterClass
{
    public string Name => "Barbarian";

    public CharacterStat CreateBaseStat()
    {
        var level = new Level(1);

        var strength = new Ability(15);
        var dexterity = new Ability(13);
        var constitution = new Ability(14);
        var intelligence = new Ability(10);
        var wisdom = new Ability(12);
        var charisma = new Ability(8);

        var health = new Health(12 + constitution.Modifier());

        return new CharacterStat(level, health, strength, dexterity, constitution, intelligence, wisdom, charisma);
    }

    public void OnLevelUp(CharacterStat stat)
    {
        stat.Strength.Value += 1;
        stat.Constitution.Value += 1;

        var increaseHealth = 7 + stat.Constitution.Modifier();
        stat.Health.MaxValue += increaseHealth;
        stat.Health.Value += increaseHealth;
    }
}
