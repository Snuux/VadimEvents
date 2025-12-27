using System;
using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [Serializable()]
    private class CurrencyViewData
    {
        public CurrencyView ViewPrefab;
        public CurrencyType CurrencyType;
    }
    
    [SerializeField] List<CurrencyViewData> _currencyViewData;
    
    [SerializeField] private Canvas _canvas;
    
    [SerializeField] private RectTransform _walletViewPrefab;
    [SerializeField] private RectTransform _currenciesPanel;
    
    [SerializeField] private CurrencyAudioView _walletAudioView;

    private Wallet _wallet;
    

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        
        RectTransform walletPanel = Instantiate(_walletViewPrefab, _canvas.transform);
        RectTransform currenciesPanel = Instantiate(_currenciesPanel, walletPanel.transform);
        
        foreach (var currencyViewData in _currencyViewData)
        {
            CurrencyView view = Instantiate(currencyViewData.ViewPrefab, currenciesPanel.transform);
            
            Currency currency = GetCoinCurrency(currencyViewData.CurrencyType);
            
            view.Initialize(currency);
            _walletAudioView.Initialize(currency);
        }
    }

    private Currency GetCoinCurrency(CurrencyType currencyType)
    {
        if (_wallet.TryGetCurrency(currencyType, out Currency currency) == false)
            Debug.LogError($"Coin Currency {currencyType} not found");
        
        return currency;
    }
}