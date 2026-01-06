using System;
using System.Collections.Generic;

namespace Homework.Reactive
{
    public class ReactiveVariable<T> : IReadOnlyReactiveVariable<T> where T : IEquatable<T>
    {
        public event Action<T, T> Changed;

        private T _value;

        public ReactiveVariable() => _value = default(T);
        public ReactiveVariable(T value) => _value = value;
    
        public T Value
        {
            get => _value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(_value, value))
                    return;
                
                T oldValue = _value;
                _value = value;
                Changed?.Invoke(oldValue, value);
            }
        }
    }
}
