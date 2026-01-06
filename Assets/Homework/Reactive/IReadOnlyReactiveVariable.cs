using System;

namespace Homework.Reactive
{
    public interface IReadOnlyReactiveVariable<out T>
    {
        event Action<T, T> Changed;
        
        T Value { get; }
    }
}