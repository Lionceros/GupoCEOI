using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class UnitCharacter : MonoBehaviour
{
    [Header("Unit Stats")]
    public int healthUnit; //Vida de la unidad
    public int damageUnit; //Daño que hace la unidad
    public float rangeUnit; //Alcance del ataque
    public int timesUnitAttackEverySecond; //Cantidad de ataques por segundo
    public int secondsToAttack; // Segundos que tarda entre cada ataque
    public int criticalDamageUnit; //Daño critico
    public float movementSpeedUnit; //Velocidad movimiento de la unidad
    protected float unitRealSpeedUnit; // Para almacenar la movementSpeedUnit

    [Header("Unit Faction")]
    public int faction; //  SE CAMBIA EN EL INSPECTOR. Numero de la faccion 1= Ally / 2 = Enemy. Evita algunos problemas como que detecte otros colliders fuera de las unidades como enemigos o aliados

    [Header("Unit type")]
    public bool isTower; //Si está tocando la torre
    public bool isRangedUnit; //Es una unidad a distancia
    public bool isMeleeUnit; //Es una unidad a corta distancia

    [Header("Is Tower Dead?")]
    public bool towerIsDead;

    [Header("Is Unit Dead?")]
    public bool unitIsDead;

    [Header("Coins Unit Give When Dead")]
    // public int coinsToInvoke; //Las monedas que cuesta invocarlo
    public int coinsWhenDie; //Las monedas que da al morir

    [Header("Attack Range")]
    public Vector2 attackDisplacement = new Vector2(0, 0);
    public float attackRadius = 1F;

    [Header("Animator")]
    public Animator animator;

    [Header("Sprite Renderer & Order")]
    public SpriteRenderer spriteR;
    public static int sortingOrder;

    protected BoxCollider2D boxCol;
    protected Rigidbody2D rb;

    private float timeSeconds = 0f;
    private float timeActual = 0f;

    protected string isAllyTag = "Ally";
    protected string isEnemyTag = "Enemy";

    public void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void MovementUnitAndLayer() //Mueve las unidades segun si son enemigas o aliadas, Se instancia en los scripts de las unidades
    {
        if (faction >= 2)
        {
            transform.Translate(Vector2.left * movementSpeedUnit * Time.deltaTime);
            gameObject.layer = 9; // Layer 9 = Enemy
        }
        else
        {
            transform.Translate(Vector2.right * movementSpeedUnit * Time.deltaTime);
            gameObject.layer = 8; // Layer 8 = Ally
        }
    }

    public void TimeToAttack(UnitCharacter unit)
    {
        animator.SetBool("Attack", true);
        timeActual += Time.deltaTime;
        if (timeActual - timeSeconds >= 1f)
        {
            timeSeconds = timeActual;

            if (unit != null && faction != unit.faction) // Si la unidad no es nula y NO es de nuestra faccion
            {
                Damage(unit);
                IsUnitDead(unit);
            }
        }
    }

    public void Damage(UnitCharacter unit)
    {
        CriticalDamage();
        unit.healthUnit -= (damageUnit * criticalDamageUnit) * timesUnitAttackEverySecond;
    }

    public void IsUnitDead(UnitCharacter unit)
    {
        if (unit.healthUnit <= 0) // Se le resta a la vida de la unidad contraria nuestro daño
        {
            unit.animator.SetBool("Die", true);

            if (unit.isTower)
            {
                unit.towerIsDead = true;

                DestroyUnits();
            }
            else
            {
                unit.unitIsDead = true;
                unit.movementSpeedUnit = 0;
                unit.attackRadius = 0;
                unit.rb.isKinematic = true;
                unit.boxCol.isTrigger = true;

                Destroy(unit.gameObject, 2f);
            }
        }
    }

    public void CriticalDamage() // Calcula el daño crítico
    {
        int criticalDamageTemp = RandomNumber(1,4);
        if (criticalDamageTemp == 3)
        {
            criticalDamageTemp = RandomNumber(1,6);
            if (criticalDamageTemp == 5)
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

    public void CheckEnemiesInRange()
    {
        Vector2 d = attackDisplacement;
        int enemyLayer = gameObject.layer == 8 ? 9 : 8;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(d.x, d.y, 0f), attackRadius, 1 << enemyLayer);
        foreach (Collider2D collider in colliders)
        {
            if (!collider.isTrigger)
            {
                // Comprobar si es una unidad
                UnitCharacter unit = collider.GetComponent<UnitCharacter>();
                if (unit && unit != this)
                {
                    movementSpeedUnit = 0f;
                    unit.TimeToAttack(this);
                }

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 d = attackDisplacement;
        Gizmos.DrawWireSphere(transform.position + new Vector3(d.x, d.y, 0F), attackRadius);
    }

    public void SortingOrder()
    {
        sortingOrder -= 1;
        spriteR.sortingOrder = sortingOrder;
    }

    void DestroyUnits()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
            foreach (GameObject enemy in units)
                GameObject.Destroy(enemy);
    }
}
