using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : UnitCharacter
{
    private void Start()
    {
        healthUnit = 100;
        damageUnit = 5;
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 5;
        movementSpeedUnit = 0f;
        unitRealSpeedUnit = movementSpeedUnit;

        IsRangedOrMeleeUnit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementUnitAndLayer();
        movementSpeedUnit = unitRealSpeedUnit;
        CheckEnemiesInRange();
    }
}