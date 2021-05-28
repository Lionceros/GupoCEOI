using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitCharacter : MonoBehaviour
{

    public int healthUnit; //Vida de la unidad
    public int damageUnit; //Daño que hace la unidad
    public float rangeUnit; //Alcance del ataque
    public int attackSpeedUnit; //Cantidad de ataques por segundo
    public int secondsToAttack; // Segundos que tarda entre cada ataque
    public int criticalDamageUnit; //Daño critico
    public float movementSpeedUnit; //Velocidad movimiento de la unidad

    public int faction; //  SE CAMBIA EN EL INSPECTOR. Numero de la faccion 1= Ally / 2 = Enemy. Evita algunos problemas como que detecte otros colliders fuera de las unidades como enemigos o aliados
    
    public bool isTower; //Si está tocando la torre
    public bool isRangedUnit; //Es una unidad a distancia
    public bool isMeleeUnit; //Es una unidad a corta distancia
    
    protected CircleCollider2D circleCol;
    protected BoxCollider2D boxCol;
    protected Rigidbody2D rb;

    private void Awake()
    {
        circleCol = GetComponent<CircleCollider2D>();
        boxCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    // virtual = Permite que se pueda sobreescribir por los hijos (Warrior, Archer, etc)
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        UnitCharacter unit = collision.gameObject.GetComponent<UnitCharacter>();

        if (unit != null && faction != unit.faction && isRangedUnit) // Si la unidad no es nula y NO es de nuestra faccion
        {
            Damage(unit);
            IsUnitDead(unit);
        }
    }

    // OnCollissionStay2D IGNORA los triggers por lo que solo funciona cuando choca con algo, perfecto para los guerreros
    // El guerrero lleva solo el circleCollider para asignarlo como Melee 
    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        UnitCharacter unit = collision.gameObject.GetComponent<UnitCharacter>();

        if (unit != null && faction != unit.faction && isMeleeUnit) // Si la unidad no es nula y NO es de nuestra faccion
        {
            Damage(unit);
            IsUnitDead(unit);
        }
    }

    public void MovementUnit() //Mueve las unidades segun si son enemigas o aliadas, Se instancia en los scripts de las unidades
    {
        if (faction >= 2)
        {
            transform.Translate(Vector2.left * movementSpeedUnit * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * movementSpeedUnit * Time.deltaTime);
        }
    }

    public void IsRangedOrMeleeUnit() // Detecta automaticamente si la unidad es a distancia o melee
    {
        if (rangeUnit >= 0.15f)
        {
            isRangedUnit = true;
        }
        else
        {
            isMeleeUnit = true;
        }
    }

    public void Damage(UnitCharacter unit)
    {
        int tempAttack = 0;
        while (tempAttack != attackSpeedUnit)
        {
            CriticalDamage();

            unit.healthUnit -= damageUnit * criticalDamageUnit;
            tempAttack += 1;
        }
        //StartCoroutine(WaitToAttack());
    }

    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(secondsToAttack);
    }

    public void CriticalDamage() // Calcula el daño crítico
    {
        int criticalDamageTemp = RandomNumber(1,3);
        if (criticalDamageTemp == 3)
        {
            criticalDamageTemp = RandomNumber(1, 6);
            if (criticalDamageTemp == 6)
            {
                criticalDamageUnit = 3;
            }
            else
            {
                criticalDamageUnit = 2;
            }
        }
        else
        {
            criticalDamageUnit = 1;
        }
    }

    public int RandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void IsUnitDead(UnitCharacter unit)
    {
        if (unit.healthUnit <= 0) // Se le resta a la vida de la unidad contraria nuestro daño
        {
            Destroy(unit.gameObject);
        }
    }
}
