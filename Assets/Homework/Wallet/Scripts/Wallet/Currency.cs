using System;
using Homework.Reactive;

namespace Homework.Wallet.Scripts.Wallet
{
    public class Currency
    {
        public event Action<float, float> Changed
        {
            add => _value.Changed += value;
            remove => _value.Changed -= value;
        }

        private ReactiveVariable<float> _value;

        public Currency(float value = 0) => _value = new ReactiveVariable<float>(value);

        public IReadOnlyReactiveVariable<float> ReactiveValue => _value;

        public float SetValue(float value)
        {
            ThrowExceptionIfValueNotPositive(value);
            _value.Value = value;
            return _value.Value;
        }

        public float AddValue(float value)
        {
            ThrowExceptionIfValueNotPositive(value);
            _value.Value += value;
            return _value.Value;
        }

        public float SubValue(float value)
        {
            ThrowExceptionIfValueNotPositive(value);

            float newValue = _value.Value - value;

            if (newValue < 0)
                _value.Value = 0;
            else
                _value.Value = newValue;

            return _value.Value;
        }

        private void ThrowExceptionIfValueNotPositive(float value)
        {
            if (value < 0)
                throw new Exception($"value is invalid {value} < 0");
        }
    }
}