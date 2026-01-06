using UnityEngine;

namespace Homework.Wallet.Scripts.Wallet.View
{
    public class CurrencyAudioView : MonoBehaviour
    {
        public const float MinPitch = 0.8f;
        public const float MaxPitch = 1.2f;
    
        [SerializeField] private AudioSource _audioSource;

        private Currency _currency;

        private void OnDestroy() => _currency.Changed -= PlayAudio;
    
        public void Initialize(Currency currency)
        {
            _currency = currency;
            _currency.Changed += PlayAudio;
        }
    
        public void PlayAudio(float oldValue, float value)
        {
            _audioSource.pitch = Random.Range(MinPitch, MaxPitch);
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}