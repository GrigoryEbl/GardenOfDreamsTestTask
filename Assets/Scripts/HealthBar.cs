using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _heatlh;

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
        _slider.value = value / 100;
    }
}
