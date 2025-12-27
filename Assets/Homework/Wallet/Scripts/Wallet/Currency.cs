using System;
using UnityEngine;

public class Currency
{
    public event Action<float> Changed;

    private float _value;
    
    public float SetValue(float value)
    {
        if (value <= 0)
        {;  
            Debug.Log("value is invalid");
            Debug.Break();
                
            return -1;
        }
        
        _value = value;
        Changed?.Invoke(_value);
        
        return _value;
    }
    
    public float AddValue(float value)
    {
        if (value < 0)
        {;  
            Debug.LogError("value is invalid");
            return -1;
        }
        
        _value += value;
        Changed?.Invoke(_value);
        
        return _value;
    }

    public float SubValue(float value)
    {
        if (value < 0)
        {;  
            Debug.LogError("value is invalid");
            return -1;
        }
        
        _value -= value;

        if (_value < 0)
        {
            _value = 0;
            Debug.LogError("value < 0");
            return _value;
        }
        
        Changed?.Invoke(_value);
        
        return _value;
    }
    
    public float GetValue() => _value;

    public Currency(float value = 0) => _value = value;
}
