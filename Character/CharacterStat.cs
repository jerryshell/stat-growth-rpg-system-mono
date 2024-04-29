using Godot;

public partial class CharacterStat : Resource
{
    public Level Level;
    public Health Health;
    public Ability Strength;
    public Ability Dexterity;
    public Ability Constitution;
    public Ability Intelligence;
    public Ability Wisdom;
    public Ability Charisma;

    public CharacterStat(Level level, Health health, Ability strength, Ability dexterity, Ability constitution, Ability intelligence, Ability wisdom, Ability charisma)
    {
        Level = level;
        Health = health;
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }
}
