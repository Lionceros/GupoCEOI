using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUnit : UnitCharacter
{
    private void Start()
    {
        healthUnit = 2;
        damageUnit = 2;
        rangeUnit = 0.15f;
        circleCol.radius = rangeUnit; // Define el radie del CircleCollider2D
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        UnitCharacter unit = collision.gameObject.GetComponent<UnitCharacter>();
        if (unit != null && faction != unit.faction && isRangedUnit) // La unidad parada vuelve a moverse
        {
            movementSpeedUnit = unitRealSpeedUnit;
        }
    }
}
