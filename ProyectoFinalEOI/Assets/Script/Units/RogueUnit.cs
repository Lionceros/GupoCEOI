using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueUnit : UnitCharacter
{
    private void Start()
    {
        healthUnit = 5;
        damageUnit = 2;
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 5;
        movementSpeedUnit = 1f;
        unitRealSpeedUnit = movementSpeedUnit;
        isMeleeUnit = true;

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
