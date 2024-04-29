using Godot;

public partial class Level : Resource
{
    [Signal]
    public delegate void LevelUpEventHandler();

    private int _value;
    public int Value
    {
        get => _value;
        private set
        {
            _value = Mathf.Max(0, value);
            EmitChanged();
        }
    }

    private int _xp;
    public int Xp
    {
        get => _xp;
        set
        {
            while (true)
            {
                if (IsMaxLevel())
                {
                    _xp = 0;
                    return;
                }

                _xp = value;
                EmitChanged();

                if (_xp < NextLevelXp())
                {
                    return;
                }

                IncreaseLevel();
            }

        }
    }

    public Level(int value)
    {
        _value = value;
    }

    public bool IsMaxLevel()
    {
        return Value >= XpDatabase.MaxLevel();
    }

    public int LevelXp()
    {
        return XpDatabase.LevelXpAt(Value);
    }

    public int NextLevelXp()
    {
        return XpDatabase.LevelXpAt(Value + 1);
    }

    public void IncreaseLevel()
    {
        Value += 1;
        EmitSignal(SignalName.LevelUp);
    }

    public int ProficiencyBouns()
    {
        return (Value - 1) / 4 + 2;
    }
}
