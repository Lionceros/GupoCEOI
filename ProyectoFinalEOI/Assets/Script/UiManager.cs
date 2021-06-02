using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiManager : MonoBehaviour
{
    public GameObject[] prefabsAlly;
    public GameObject invokeAlly;

    public GameObject[] prefabsEnemy;
    public GameObject invokeEnemy;

    public float timeSeconds = 0f;
    public float timeActual = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeToInvokeEnemy();
    }

    public void InvokeEnemy()
    {
        int tempRandom = RandomNumber(0, 2);
        Instantiate(prefabsEnemy[tempRandom], invokeEnemy.transform);

    }


    public void InvokeAllyWarrior()
    {
        Instantiate(prefabsAlly[0], invokeAlly.transform);
    }
    public void InvokeAllyArcher()
    {
        Instantiate(prefabsAlly[1], invokeAlly.transform);
    }

    public int RandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void TimeToInvokeEnemy()
    {
        timeActual += Time.fixedDeltaTime;
        if (timeActual - timeSeconds >= 20f)
        {
            timeSeconds = timeActual;

            InvokeEnemy();
        }
    }
}
