using UnityEngine;

public class MagazineCartridges : MonoBehaviour
{
    [SerializeField] private int _cartridgesCount;

    public void AddCartriges(int value)
    {
        _cartridgesCount += value;
    }

    public bool TryGetCartridge()
    {
        if (_cartridgesCount > 0)
        {
            _cartridgesCount -= 1;
            return true;
        }

        return false;
    }
}
