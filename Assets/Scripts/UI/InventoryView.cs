using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Cell _cellPrefab;

    private Cell[] _cells;
    private int _cellCount = 10;

    private void Awake()
    {
        _cells = new Cell[_cellCount];
        CreateCells();
    }

    private void OnEnable()
    {
        Redraw();
    }

    private void CreateCells()
    {
        for (int i = 0; i < _cellCount; i++)
        {
           var _cell = Instantiate(_cellPrefab, transform);
            _cells[i] = _cell;
        }
    }

    private void Redraw()
    {
        for (int i = 0; i < _inventory.Items.Count; i++)
        {
            _cells[i].Fill(_inventory.Items[i]);
        }
    }
}
