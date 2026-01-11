using System;
using Homework.Reactive;

namespace Homework.Wallet.Scripts.Wallet
{
    public interface IReadOnlyCurrency
    {
        public event Action<float, float> Changed;
        
        public IReadOnlyReactiveVariable<float> ReactiveValue { get; }
    }
}