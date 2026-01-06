using Homework.Wallet.Scripts.Wallet.View;
using UnityEngine;

namespace Homework.Wallet.Scripts.Wallet
{
    public class PlayerExample : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;
    
        private Wallet _playerWallet;

        private void Awake()
        {
            _playerWallet = new Wallet();

            _playerWallet.AddValue(CurrencyType.Coins, 0);
            _playerWallet.AddValue(CurrencyType.PremiumCoins, 0);
            _playerWallet.AddValue(CurrencyType.Energy, 10);
        
            _walletView.Initialize(_playerWallet);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _playerWallet.AddValue(CurrencyType.Coins, 1);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                _playerWallet.AddValue(CurrencyType.PremiumCoins, 1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                _playerWallet.TrySubValue(CurrencyType.Energy, 1);
        }
    }
}