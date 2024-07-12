using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _heatlh;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _heatlh.HealthChange += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _heatlh.HealthChange -= ChangeSliderValue;
    }

    private void ChangeSliderValue(int value)
    {
        _slider.value = value;
        _text.text = value.ToString();
    }
}
