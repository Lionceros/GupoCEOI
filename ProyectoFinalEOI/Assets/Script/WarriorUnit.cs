using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorUnit : UnitCharacter
{
    private void Start()
    {
        healthUnit = 20;
        damageUnit = 1;
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 5;
        movementSpeedUnit = 1f;
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
