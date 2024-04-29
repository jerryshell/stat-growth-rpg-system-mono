using Godot;

public partial class Ability : Resource
{
    private int _value;
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            EmitChanged();
        }
    }

    public Ability(int value)
    {
        _value = value;
    }

    public int Modifier()
    {
        return Mathf.FloorToInt((Value - 10) / 2f);
    }
}
