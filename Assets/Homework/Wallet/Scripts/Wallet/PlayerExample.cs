using UnityEngine;

public class PlayerExample : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    
    private Wallet _playerWallet;

    public Wallet PlayerWallet => _playerWallet;

    private void Awake()
    {
        _playerWallet = new Wallet();

        _playerWallet.AddValue(CurrencyType.Coins, 0);
        _playerWallet.AddValue(CurrencyType.PremiumCoins, 0);
        _playerWallet.AddValue(CurrencyType.Energy, 100);
        
        _walletView.Initialize(_playerWallet);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            _playerWallet.AddValue(CurrencyType.Coins, 1);
        if (Input.GetKey(KeyCode.Alpha2))
            _playerWallet.AddValue(CurrencyType.PremiumCoins, 1);
        if (Input.GetKey(KeyCode.Alpha3))
            _playerWallet.SubValue(CurrencyType.Energy, 1);
    }
}