using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> _items = new List<Item>();

    public IReadOnlyList<Item> Items => _items;

    public void Add(Item item)
    {
        if (item.IsStacking && _items != null)
            Stacking(item);
        else
            _items.Add(item);
    }

    public void Remove(ref Item item)
    {
        _items.Remove(item);
    }

    private void Stacking(Item item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Name == item.Name)
            {
                _items[i].StackCount(_items[i].Count + item.Count);
                return;
            }
        }

        _items.Add(item);
    }
}
