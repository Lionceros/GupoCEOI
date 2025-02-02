﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : UnitCharacter
{
    private void Start()
    {
        healthUnit = 10;
        damageUnit = 5;
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 1;
        movementSpeedUnit = 0f;
        unitRealSpeedUnit = movementSpeedUnit;
        isTower = true;
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