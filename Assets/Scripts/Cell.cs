using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Cell : MonoBehaviour
{
    [SerializeField] private Button _clearButton;
    [SerializeField] private TMP_Text _textCount;

    private Item _item;
    private GameObject _icon;

    private void OnEnable()
    {
        _clearButton.onClick.AddListener(ClearSelf);
    }

    private void OnDisable()
    {
        _clearButton.onClick.RemoveListener(ClearSelf);
    }

    public void Fill(Item item)
    {
        if (item.Count > 0)
            _textCount.text = item.Count.ToString();

        if (_icon != null)
            return;

        _icon = new GameObject(name: item.Name);
        _icon.transform.SetParent(transform, false);
        _icon.AddComponent<Item>();
        _item = item;
        _icon.AddComponent<RectTransform>();
        _icon.AddComponent<Image>().sprite = item.Icon;

        _icon.transform.SetSiblingIndex(0);
    }

    private void ClearSelf()
    {
        if (_item != null)
        {
            Inventory inventory = FindAnyObjectByType<Inventory>();
            inventory.Remove(ref _item);
            Destroy(_icon.gameObject);
            _textCount.text = "";
        }
    }
}
