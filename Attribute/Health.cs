using Godot;

public partial class Health : Resource
{
    private int _maxValue;
    public int MaxValue
    {
        get => _maxValue;
        set
        {
            _maxValue = Mathf.Max(0, value);
            EmitChanged();
        }
    }

    private int _value;
    public int Value
    {
        get => _value;
        set
        {
            _value = Mathf.Min(MaxValue, value);
            EmitChanged();
        }
    }

    public Health(int maxValue)
    {
        _maxValue = maxValue;
        _value = maxValue;
    }

    public Health(int maxValue, int value)
    {
        _maxValue = maxValue;
        _value = value;
    }

    public void Refill()
    {
        Value = MaxValue;
    }
}
