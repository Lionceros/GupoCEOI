using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageUnit : UnitCharacter
{
    private void Start()
    {
        healthUnit = 3;
        damageUnit = 10;
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 5;
        movementSpeedUnit = 1f;
        unitRealSpeedUnit = movementSpeedUnit;
        isRangedUnit = true;

        IsRangedOrMeleeUnit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementUnitAndLayer();
        movementSpeedUnit = unitRealSpeedUnit;
        animator.SetBool("Attack", false);
        CheckEnemiesInRange();
    }
}
