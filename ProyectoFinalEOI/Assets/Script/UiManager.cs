using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class UiManager : MonoBehaviour
{
    [Header("Time To Invoke Enemy")]
    public float timeToInvokeEnemy;

    [Header("Units Prefabs")]
    public UnitCharacter[] prefabsAlly;
    public UnitCharacter[] prefabsEnemy;

    [Header("Units Buttons")]
    public GameObject[] buttonAlly;

    [Header("Invocadores")]
    public GameObject invokeAlly;
    public GameObject invokeEnemy;

    [Header("Towers")]
    public UnitCharacter allyTower;
    public UnitCharacter enemyTower;

    private float timeSeconds = 0f;
    private float timeActual = 0f;

    private float timeStart;
    private int minutes;
    private int seconds;
    private int miliseconds;

    [Header("Panels Victory & GameOver")]
    public GameObject gameOver;
    public GameObject gameVictory;

    [Header("CoinManager")]
    public CoinManager coinManager;

    [Header("Crono Text")]
    public TextMeshProUGUI timerText;

    private void Start()
    {
        timeStart = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeToInvokeEnemy();
        GameOver();
        Victory();
        Chrono();
    }

    public void WhichEnemyToInvoke()
    {
        int tempRandom = RandomNumber(0, 4);

        if (tempRandom == 0)
        {
            InvokeEnemyWarrior(tempRandom);
        }
        else if (tempRandom == 1)
        {
            InvokeEnemyArcher(tempRandom);
        }
        else if (tempRandom == 2)
        {
            InvokeEnemyRogue(tempRandom);
        }
        else if (tempRandom == 3)
        {
            InvokeEnemyMage(tempRandom);
        }
    }


    public void InvokeAllyWarrior()
    {
        if (coinManager.coinsAlly >= coinManager.warriorPrice)
        {
            int temp = coinManager.coinsAlly -= coinManager.warriorPrice;
            coinManager.coinVariable.text = temp.ToString();
            InvokeAlly(0);
        }
        
    }
    public void InvokeAllyArcher()
    {
        if (coinManager.coinsAlly >= coinManager.archerPrice)
        {
            int temp = coinManager.coinsAlly -= coinManager.archerPrice;
            coinManager.coinVariable.text = temp.ToString();
            InvokeAlly(1);
        }
    }

    public void InvokeAllyRogue()
    {
        if (coinManager.coinsAlly >= coinManager.roguePrice)
        {
            int temp = coinManager.coinsAlly -= coinManager.roguePrice;
            coinManager.coinVariable.text = temp.ToString();
            InvokeAlly(2);
        }
    }

    public void InvokeAllyMage()
    {
        if (coinManager.coinsAlly >= coinManager.magePrice)
        {
            int temp = coinManager.coinsAlly -= coinManager.magePrice;
            coinManager.coinVariable.text = temp.ToString();
            InvokeAlly(0);
        }
    }

    public void TimeToInvokeEnemy()
    {
        if (allyTower.towerIsDead || enemyTower.towerIsDead)
        {
            
        }
        else
        {
            timeActual += Time.deltaTime;
            if (timeActual - timeSeconds >= timeToInvokeEnemy)
            {
                timeSeconds = timeActual;

                WhichEnemyToInvoke();
            }
        }
        
    }

    public int RandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void InvokeAlly(int idPrefab)
    {
        if (allyTower.towerIsDead || enemyTower.towerIsDead)
        {
            for (int i = 0; i >= 4; i++)
            {
                Button temp = buttonAlly[i].GetComponent<Button>();
                temp.SetEnabled(false);
            }
        }
        else
        {
            UnitCharacter temp = Instantiate(prefabsAlly[idPrefab], invokeAlly.transform);
            UnitCharacter unit = temp.GetComponent<UnitCharacter>();
            unit.SortingOrder();
            GiveCoinFromDeadUnit(unit);
        }
        
    }

    public void GameOver()
    {
        if (allyTower.towerIsDead)
        {
            enemyTower.animator.SetBool("Win", true);
            gameOver.SetActive(true);
        }
    }
    public void Victory()
    {
        if (enemyTower.towerIsDead)
        {
            allyTower.animator.SetBool("Win", true);
            gameVictory.SetActive(true);
        }
    }

    public void StopGame()
    {
        if (allyTower.towerIsDead || enemyTower.towerIsDead)
        {

        }
        else
        {
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0F;
            else
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        
    }

    public void GiveCoinFromDeadUnit(UnitCharacter unit)
    {
        if (unit.unitIsDead)
        {
            Debug.Log("Unidad muerta");
            int temp = coinManager.coinsAlly += unit.coinsWhenDie;
            coinManager.coinVariable.text = temp.ToString();
        }

    }

    public void InvokeEnemyWarrior(int random)
    {
        if (coinManager.coinsEnemy >= coinManager.warriorPrice)
        {
            int temp = coinManager.coinsEnemy -= coinManager.warriorPrice;
            coinManager.coinVariable.text = temp.ToString();

            InvokeEnemy(random);
        } 
    }

    public void InvokeEnemyArcher(int random)
    {
        if (coinManager.coinsEnemy >= coinManager.archerPrice)
        {
            int temp = coinManager.coinsEnemy -= coinManager.archerPrice;
            coinManager.coinVariable.text = temp.ToString();

            InvokeEnemy(random);
        }
    }

    public void InvokeEnemyRogue(int random)
    {
        if (coinManager.coinsEnemy >= coinManager.roguePrice)
        {
            int temp = coinManager.coinsEnemy -= coinManager.roguePrice;
            coinManager.coinVariable.text = temp.ToString();

            InvokeEnemy(random);
        }
    }

    public void InvokeEnemyMage(int random)
    {
        if (coinManager.coinsEnemy >= coinManager.magePrice)
        {
            int temp = coinManager.coinsEnemy -= coinManager.magePrice;
            coinManager.coinVariable.text = temp.ToString();

            InvokeEnemy(random);
        }
    }

    public void InvokeEnemy(int random)
    {
        UnitCharacter temp2 = Instantiate(prefabsEnemy[random], invokeEnemy.transform);
        UnitCharacter unit = temp2.GetComponent<UnitCharacter>();
        unit.SortingOrder();
    }
    public void Chrono()
    {
        float time = Time.time - timeStart;

        minutes = ((int)time / 60);
        seconds = ((int)time % 60);
        miliseconds = ((int)(time * 100) % 100);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
    }
}
