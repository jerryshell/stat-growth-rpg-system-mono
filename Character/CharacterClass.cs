public partial interface CharacterClass
{
    public string Name { get; }

    public CharacterStat CreateBaseStat();

    public void OnLevelUp(CharacterStat stat);
}
