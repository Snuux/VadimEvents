using System;
using System.Collections.Generic;

public class Wallet
{
    private Dictionary<CurrencyType, Currency> _currencies = new();
    
    public IEnumerable<Currency> Currencies => _currencies.Values;

    public void AddValue(CurrencyType currencyType, float value)
    {
        if (_currencies.ContainsKey(currencyType) == false)
            _currencies.Add(currencyType, new Currency());

        _currencies[currencyType].AddValue(value);
    }
    
    public void SubValue(CurrencyType currencyType, float value)
    {
        if (_currencies.ContainsKey(currencyType) == false)
            _currencies.Add(currencyType, new Currency());

        _currencies[currencyType].SubValue(value);
    }

    public bool TryGetValue(CurrencyType currencyType, out float value)
    {
        value = 0f;
        
        if (_currencies.ContainsKey(currencyType) == false)
            return false;
        
        value = _currencies[currencyType].GetValue();
        
        return true;
    }

    public bool TryGetCurrency(CurrencyType currencyType, out  Currency currency)
    {
        currency = null;

        if (_currencies.ContainsKey(currencyType) == false)
            return false;
        
        currency = _currencies[currencyType];
        
        return true;
    }
}
