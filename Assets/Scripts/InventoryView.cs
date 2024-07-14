using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _inventoryPanel;

    private void Start()
    {
        Redraw();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Redraw() ;
        }
    }

    void Redraw()
    {
        for (int i = 0; i < _inventory.items.Count; i++)
        {
            var item = _inventory.items[i];

            var icon = new GameObject(name: item.Name);

            icon.AddComponent<RectTransform>();
            icon.AddComponent<SpriteRenderer>().sprite = item.Icon;

            icon.transform.position = new Vector3(0,0, 0);
            icon.transform.parent = _inventoryPanel;

            print("Create" + item.name);
        }
    }
}
