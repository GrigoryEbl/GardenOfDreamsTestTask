using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStacking;

    public string Name => _name;
    public Sprite Icon => _icon;
    public bool IsStacking => _isStacking;
}
