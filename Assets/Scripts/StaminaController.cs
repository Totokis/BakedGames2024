using System;
using System.Collections;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    public Int32 _staminaPoints;

    public Int32 SlideCost;
    public Int32 RecoveryTime;
    public Int32 StaminaRecoveryValue;
    public Int32 StaminaPoints => _staminaPoints;
    void Start()
    {
        _staminaPoints = 100;
        StartCoroutine(AddStamina());
    }

    public Boolean CanUseSlide()
    {
        return _staminaPoints >= SlideCost;
    }
    public void UseSlide()
    {
        _staminaPoints -= 30;
        if(_staminaPoints < 0)
            _staminaPoints = 0;
    }

    void Update()
    {
        print(_staminaPoints);
    }

    IEnumerator AddStamina()
    {
        if(_staminaPoints < 100)
            _staminaPoints += StaminaRecoveryValue;

        yield return new WaitForSeconds(RecoveryTime);
        StartCoroutine(AddStamina());

    }
}
