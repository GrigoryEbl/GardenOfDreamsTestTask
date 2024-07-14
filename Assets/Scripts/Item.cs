using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStacking;
    [SerializeField] private int _count;

    public string Name => _name;
    public Sprite Icon => _icon;
    public bool IsStacking => _isStacking;
    public int Count => _count;

    public void StackCount(int count)
    {
        if (count >= 0)
            _count = count;
    }
}
