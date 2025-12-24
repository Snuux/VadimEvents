using System;

public class Currency
{
    public event Action Changed;

    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            Changed?.Invoke();
        }
    }

    public Currency(int value = 0) => _value = value;
}
