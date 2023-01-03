using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private HealthManager healthManager;

    private void Start()
    {
        ChangeSliderValue(healthManager.health);
    }

    private void OnEnable()
    {
        healthManager.healthChangeEvent.AddListener(ChangeSliderValue);
    }

    private void OnDisable()
    {
        healthManager.healthChangeEvent.RemoveListener(ChangeSliderValue);
    }

    private void ChangeSliderValue(int health)
    {
        slider.value = (float)health / 100;
    }
}