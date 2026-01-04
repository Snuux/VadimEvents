using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currencyText;

    private Currency _currency;

    private void OnDestroy()
    {
        _currency.ReactiveValue.Changed -= UpdateValueText;
    }

    public void Initialize(Currency currency)
    {
        _currency = currency;
        _currency.ReactiveValue.Changed += UpdateValueText;
        
        UpdateValueText(_currency.ReactiveValue.Value, _currency.ReactiveValue.Value);
    }

    public void UpdateValueText(float oldValue, float value) => _currencyText.text = value.ToString();
}