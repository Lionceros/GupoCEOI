using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : UnitCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        healthUnit = 100;
        isTower = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //// override= Sobrescribe al OnTriggerStay2D de las unidades a distancia (Archer, Mage)
    //protected override void OnTriggerStay2D(Collider2D collision)
    //{
    //    base.OnTriggerStay2D(collision); // Si no se añade esto, lo que pongamos aquí sustituirá al OnTriggerStay2D
    //                                     // de UnitCharacter. Con esto puesto hace los del OnTriggerStay2D de
    //                                     // UnitCharacter mas lo que le pongamos.
    //}



    //// override= Sobrescribe al OnCollissionStay2D de las unidades a melee (Guerrero, Ranger)
    //protected override void OnCollisionStay2D(Collision2D collision)
    //{
    //    base.OnCollisionStay2D(collision); // Si no se añade esto, lo que pongamos aquí sustituirá al OnCollissionStay2D
    //                                       // de UnitCharacter. Con esto puesto hace los del OnCollissionStay2D de
    //                                       // UnitCharacter mas lo que le pongamos.
    //}

}
