using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializedHashSet<T> : ICollection<T>
{
    private readonly HashSet<T> set;
    [SerializeField]
    private List<T> list;

    public int Count => set.Count;

    public bool IsReadOnly => false;

    public SerializedHashSet()
    {
        set = new();
        list = new();
    }

    public void Refresh()
    {
        set.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            set.Add(list[i]);
        }
    }

    public void Add(T item)
    {
        if (set.Add(item))
        {
            list.Add(item);
        }
    }

    public void Clear()
    {
        set.Clear();
        list.Clear();
    }

    public bool Contains(T item)
    {
        return set.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        if(set.Contains(item))
        {
            set.Remove(item);
            list.Remove(item);
            return true;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}