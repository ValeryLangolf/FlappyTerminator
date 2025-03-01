using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour, IDeactivatable<T>
{
    [SerializeField] private T _prefab;

    private readonly Stack<T> _elements = new();

    public T Get()
    {
        T element = _elements.Count == 0 ? Instantiate(_prefab, transform) : _elements.Pop();
        element.Deactivated += ReturnInPool;

        return element;
    }

    private void ReturnInPool(T element)
    {
        element.Deactivated -= ReturnInPool;
        _elements.Push(element);
    }
}