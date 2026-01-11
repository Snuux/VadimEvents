using System.Collections.Generic;

namespace Homework.Wallet.Scripts.Wallet
{
    public class Wallet
    {
        private readonly Dictionary<CurrencyType, IReadOnlyCurrency> _currencies = new();
    
        public IReadOnlyDictionary<CurrencyType, IReadOnlyCurrency> Currencies => _currencies;

        public void AddValue(CurrencyType currencyType, float value)
        {
            if (_currencies.ContainsKey(currencyType) == false)
                _currencies.Add(currencyType, new Currency());

            (_currencies[currencyType] as Currency)?.AddValue(value);
        }
    
        public bool TrySubValue(CurrencyType currencyType, float value)
        {
            if (_currencies.ContainsKey(currencyType) == false)
                return false;

            float difference = _currencies[currencyType].ReactiveValue.Value - value;
            if (difference < 0)
                return false;
            
            (_currencies[currencyType] as Currency)?.SubValue(value);
            return true;
        }

        public bool TryGetValue(CurrencyType currencyType, out float value)
        {
            if (TryGetCurrency(currencyType, out IReadOnlyCurrency currency) == false)
            {
                value = 0;
                return false;
            }
            
            value = currency.ReactiveValue.Value;
            return true;
        }

        public bool TryGetCurrency(CurrencyType currencyType, out IReadOnlyCurrency currency)
        {
            currency = null;

            if (_currencies.ContainsKey(currencyType) == false)
                return false;
        
            currency = _currencies[currencyType];
        
            return true;
        }
    }
}
