using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CoinManager : MonoBehaviour
{
    UiManager uiManager;

    [Header("Units Prices")]
    public int warriorPrice;
    public int archerPrice;
    public int roguePrice;
    public int magePrice;

    [Header("Units Text")]
    public TextMeshProUGUI warriorText;
    public TextMeshProUGUI archerText;
    public TextMeshProUGUI rogueText;
    public TextMeshProUGUI mageText;

    [Header("Towers")]
    public UnitCharacter allyTower;
    public UnitCharacter enemyTower;

    [Header("Coins")]
    public int coinsOnStart; // Monedas que tenemos al inicio de la partida
    public int coinsEverySecond; //Monedas cada segundo

    [Header("Coins Text")]
    public TextMeshProUGUI coinVariable;

    [Header("Total Coins")]
    public int coinsAlly; //Monedas totales de los aliados
    public int coinsEnemy; //Monedas totales de los enemigos

    private float timeSeconds = 0f;
    private float timeActual = 0f;

    // Start is called before the first frame update
    void Start()
    {
        CoinOnStart();
    }

    // Update is called once per frame
    void Update()
    {
        Manager();
    }

    public void CoinOnStart()
    {
        coinsAlly += coinsOnStart;
        coinsEnemy += coinsOnStart;
        coinVariable.text = coinsOnStart.ToString();
        UnitStartPrices();
    }

    public void UnitStartPrices()
    {
        warriorText.text = warriorPrice.ToString();
        archerText.text = archerPrice.ToString();
        rogueText.text = roguePrice.ToString();
        mageText.text = magePrice.ToString();
    }

    public void Manager()
    {
        CoinPerSecondAlly();
        CoinPerSecondEnemy();
    }

    public void CoinPerSecondAlly()
    {
        timeActual += Time.deltaTime;
        if (timeActual - timeSeconds >= 1f)
        {
            timeSeconds = timeActual;
            int temp = coinsAlly += coinsEverySecond;
            coinVariable.text = coinsAlly.ToString();
        }
    }
    public void CoinPerSecondEnemy()
    {
        timeActual += Time.deltaTime;
        if (timeActual - timeSeconds >= 1f)
        {
            timeSeconds = timeActual;
            int temp = coinsEnemy += coinsEverySecond;
        }
    }
}
