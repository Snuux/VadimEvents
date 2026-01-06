using TMPro;
using UnityEngine;

namespace Homework.Wallet.Scripts.Wallet.View
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyText;

        private Currency _currency;

        private void OnDestroy()
        {
            _currency.Changed -= UpdateValueText;
        }

        public void Initialize(Currency currency)
        {
            _currency = currency;
            _currency.Changed += UpdateValueText;
        
            UpdateValueText(_currency.ReactiveValue.Value, _currency.ReactiveValue.Value);
        }

        public void UpdateValueText(float oldValue, float value) => _currencyText.text = value.ToString();
    }
}