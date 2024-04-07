using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Int32 _staminaPoints;

    public Int32 SlideCost;
    public Single RecoveryTime;
    public Int32 StaminaRecoveryValue;
    public Int32 StaminaPoints => _staminaPoints;

    public Slider slider;
    void Start()
    {
        _staminaPoints = 100;
        UpdateUI();
        StartCoroutine(AddStamina());
    }

    public Boolean CanUseSlide()
    {
        return _staminaPoints >= SlideCost;
    }
    public void UseSlide()
    {
        _staminaPoints -= 30;
        UpdateUI();
        if (_staminaPoints < 0)
        {
            _staminaPoints = 0;
            UpdateUI();
        }
    }

    IEnumerator AddStamina()
    {
        if(_staminaPoints < 100)
        {
            _staminaPoints += StaminaRecoveryValue;
            UpdateUI();
        }

        yield return new WaitForSeconds(RecoveryTime);
        StartCoroutine(AddStamina());
    }

    void UpdateUI()
    {
        slider.value = _staminaPoints;
    }
}
