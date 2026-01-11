using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework.Wallet.Scripts.Wallet.View
{
    public class WalletView : MonoBehaviour
    {
        [Serializable()]
        private class CurrencyViewData
        {
            public CurrencyView ViewPrefab;
            public CurrencyType CurrencyType;
        }
    
        [SerializeField] List<CurrencyViewData> _currencyViewDataList;
    
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
        
            foreach (var currency in _wallet.Currencies)
            {
                if (TryFindMappedCurrency(currency.Key, out CurrencyViewData viewData))
                {
                    CurrencyView view = Instantiate(viewData.ViewPrefab, currenciesPanel.transform);
                    IReadOnlyCurrency currentCurrency = GetCoinCurrency(viewData.CurrencyType);
                    view.Initialize(currentCurrency);
                    _walletAudioView.Initialize(currentCurrency);
                }
                else
                {
                    throw new Exception($"For Currency \"{currency.Key}\" not found DataView");
                }
            }
        }

        private IReadOnlyCurrency GetCoinCurrency(CurrencyType currencyType)
        {
            if (_wallet.TryGetCurrency(currencyType, out IReadOnlyCurrency currency) == false)
                Debug.LogError($"Coin Currency {currencyType} not found");
        
            return currency;
        }

        private bool TryFindMappedCurrency(CurrencyType currencyType, out CurrencyViewData viewData)
        {
            foreach (var currencyViewData in _currencyViewDataList)
            {
                if (currencyType == currencyViewData.CurrencyType)
                {
                    viewData = currencyViewData;
                    return true;
                }
            }
        
            viewData = null;
            return false;
        }
    }
}