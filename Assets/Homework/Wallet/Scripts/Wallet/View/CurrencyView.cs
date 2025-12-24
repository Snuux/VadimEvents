using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currencyText;

    private Currency _currency;

    private void OnDestroy() => _currency.Changed -= UpdateValueText;

    public void Initialize(Currency currency)
    {
        _currency = currency;
        _currency.Changed += UpdateValueText;
        UpdateValueText();
    }

    public void UpdateValueText() => _currencyText.text = _currency.Value.ToString();
}