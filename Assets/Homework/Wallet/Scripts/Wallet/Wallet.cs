using System;
using System.Collections.Generic;

public class Wallet
{
    private Dictionary<CurrencyType, Currency> _currencies = new();

    public void AddCurrency(CurrencyType currencyType) => _currencies.Add(currencyType, new Currency());

    public void SetValue(CurrencyType currencyType, int value) => _currencies[currencyType].Value = value;

    public void AddValue(CurrencyType currencyType, int value) =>
        SetValue(currencyType, _currencies[currencyType].Value += value);

    public int GetValue(CurrencyType currencyType) => _currencies[currencyType].Value;

    public Currency GetCurrency(CurrencyType currencyType) => _currencies[currencyType];
}
