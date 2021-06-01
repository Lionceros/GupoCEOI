﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorUnit : UnitCharacter
{
    private void Start()
    {
        healthUnit = 3;
        damageUnit = 1;
        rangeUnit = 0.08f;
        circleCol.radius = rangeUnit; // Define el radie del CircleCollider2D
        timesUnitAttackEverySecond = 1;
        secondsToAttack = 5;
        movementSpeedUnit = 1f;

        IsRangedOrMeleeUnit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementUnitAndLayer();

    }

    // override= Sobrescribe al OnTriggerStay2D de las unidades a distancia (Archer, Mage)
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision); // Si no se añade esto, lo que pongamos aquí sustituirá al OnTriggerStay2D
                                         // de UnitCharacter. Con esto puesto hace los del OnTriggerStay2D de
                                         // UnitCharacter mas lo que le pongamos.

        UnitCharacter unit = collision.gameObject.GetComponent<UnitCharacter>();
        TimeToAttack(unit);
    }
}
