using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorUnit : UnitCharacter
{
    private void Start()
    {
        healthUnit = 5;
        damageUnit = 1;
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 5;
        movementSpeedUnit = 7f;
        unitRealSpeedUnit = movementSpeedUnit;
        isRangedUnit = true;

        // coinsToInvoke = 10; Modificar en CoinsManager!
        coinsWhenDie = 5;
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
