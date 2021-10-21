using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUnit : UnitCharacter
{
    private void Start()
    {
        healthUnit = 70;
        damageUnit = 35;
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 5;
        movementSpeedUnit = 7f;
        unitRealSpeedUnit = movementSpeedUnit;
        isRangedUnit = true;

        // coinsToInvoke = 10; Modificar en CoinsManager!
        coinsWhenDie = 5;
        pointsWhenDie = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (unitIsDead == false)
        {
            MovementUnitAndLayer();
            movementSpeedUnit = unitRealSpeedUnit;
            CheckEnemiesInRange();
        }
        //animator.SetBool("Attack", false);
    }
}
