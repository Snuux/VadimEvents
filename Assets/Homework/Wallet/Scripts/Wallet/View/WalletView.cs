using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    
    [SerializeField] private RectTransform _walletViewPrefab;
    [SerializeField] private RectTransform _currenciesPanel;
    
    [SerializeField] private CurrencyView _coinsViewPrefab;
    [SerializeField] private CurrencyView _coinsPremiumViewPrefab;
    [SerializeField] private CurrencyView _energyViewPrefab;
    
    [SerializeField] private CurrencyAudioView _walletAudioView;

    [SerializeField] private PlayerExample _playerExample;


    private void Start()
    {
        RectTransform walletPanel = Instantiate(_walletViewPrefab, _canvas.transform);
        RectTransform currenciesPanel = Instantiate(_currenciesPanel, walletPanel.transform);
        
        CurrencyView coinsView = Instantiate(_coinsViewPrefab, currenciesPanel.transform);
        CurrencyView coinsPremiumView = Instantiate(_coinsPremiumViewPrefab, currenciesPanel.transform);
        CurrencyView energyView = Instantiate(_energyViewPrefab, currenciesPanel.transform);

        coinsView.Initialize(_playerExample.PlayerWallet.GetCurrency(CurrencyType.Coins));
        coinsPremiumView.Initialize(_playerExample.PlayerWallet.GetCurrency(CurrencyType.PremiumCoins));
        energyView.Initialize(_playerExample.PlayerWallet.GetCurrency(CurrencyType.Energy));

        _walletAudioView.Initialize(_playerExample.PlayerWallet.GetCurrency(CurrencyType.Coins));
        _walletAudioView.Initialize(_playerExample.PlayerWallet.GetCurrency(CurrencyType.PremiumCoins));
        _walletAudioView.Initialize(_playerExample.PlayerWallet.GetCurrency(CurrencyType.Energy));
    }
}