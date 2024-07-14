using System.Collections.Generic;
using UnityEngine;
using YG;

public class Inventory : MonoBehaviour
{
    private List<Item> _items = new List<Item>();

    public IReadOnlyList<Item> Items => _items;

    private void Awake()
    {
        GetLoad();
    }

    public void Add(Item item)
    {
        if (item.IsStacking && _items != null)
            Stacking(item);
        else
            _items.Add(item);

        Save();
    }

    public void Remove(ref Item item)
    {
        _items.Remove(item);
        Save();
    }

    public void Stacking(Item item)
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
        Save();
    }

    public int Stacking(Item item, int decrement)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Name == item.Name)
            {
                if (_items[i].Count >= decrement)
                {
                    _items[i].StackCount(_items[i].Count - decrement);
                    return decrement;
                }
                else
                {
                    int returnedValue = _items[i].Count;
                    Remove(ref item);
                    return returnedValue;
                }
            }
        }

        Save();
        return 0;
    }

    private void Save()
    {
        YandexGame.savesData.Items = _items;

        for (int i = 0; i < _items.Count; i++)
        {
            YandexGame.savesData.Items[i].StackCount(_items[i].Count);
            print(_items[i].Name + ':' + _items[i].Count);
        }

        YandexGame.SaveProgress();
    }

    private void GetLoad()
    {
        _items = YandexGame.savesData.Items;

        for (int i = 0; i < YandexGame.savesData.Items.Count; i++)
        {
            _items[i].StackCount(YandexGame.savesData.Items[i].Count);
            print(YandexGame.savesData.Items[i].Name + ':' + YandexGame.savesData.Items[i].Count);
        }
    }
}
