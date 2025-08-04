using System;
using UnityEngine;

public class ReactiveVariable<T> where T : IEquatable<T>
{
    public event Action<T, T> Changed;

    private T _value;

    public ReactiveVariable(T value) => _value = value;
    public ReactiveVariable() => _value = default;

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value;
            _value = value;

            if (_value.Equals(oldValue) == false)
                Changed?.Invoke(oldValue, value);
        }
    }
}
