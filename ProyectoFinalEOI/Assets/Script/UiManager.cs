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

    [SerializeField]
    //UnitCharacter unit;

    public float timeSeconds = 0f;
    public float timeActual = 0f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TimeToInvokeEnemy();
    }

    public void InvokeEnemy()
    {
        int tempRandom = RandomNumber(0, 4);
        Instantiate(prefabsEnemy[tempRandom], invokeEnemy.transform);
        //unit.SortingOrder();
    }


    public void InvokeAllyWarrior()
    {
        Instantiate(prefabsAlly[0], invokeAlly.transform);
        //unit.SortingOrder();
    }
    public void InvokeAllyArcher()
    {
        Instantiate(prefabsAlly[1], invokeAlly.transform);
        //unit.SortingOrder();
    }

    public void InvokeAllyRogue()
    {
        Instantiate(prefabsAlly[2], invokeAlly.transform);
        //unit.SortingOrder();
    }

    public void InvokeAllyMage()
    {
        Instantiate(prefabsAlly[3], invokeAlly.transform);
        //unit.SortingOrder();
    }

    public void TimeToInvokeEnemy()
    {
        timeActual += Time.fixedDeltaTime;
        if (timeActual - timeSeconds >= 5f)
        {
            timeSeconds = timeActual;

            InvokeEnemy();
        }
    }

    public int RandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}
