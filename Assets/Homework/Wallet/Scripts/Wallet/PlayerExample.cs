using UnityEngine;

public class PlayerExample : MonoBehaviour
{
    private Wallet _playerWallet;

    public Wallet PlayerWallet => _playerWallet;

    private void Awake()
    {
        _playerWallet = new Wallet();

        _playerWallet.AddCurrency(CurrencyType.Coins);
        _playerWallet.AddCurrency(CurrencyType.PremiumCoins);
        _playerWallet.AddCurrency(CurrencyType.Energy);

        _playerWallet.SetValue(CurrencyType.Coins, 0);
        _playerWallet.SetValue(CurrencyType.PremiumCoins, 0);
        _playerWallet.SetValue(CurrencyType.Energy, 100);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _playerWallet.AddValue(CurrencyType.Coins, 1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _playerWallet.AddValue(CurrencyType.PremiumCoins, 1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _playerWallet.AddValue(CurrencyType.Energy, -1);
    }
}