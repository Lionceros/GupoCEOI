using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cerrar : MonoBehaviour
{


    public GameObject MenuSonido;
    public void CerrarMenu()
    {
        MenuSonido.SetActive(false);
    }
}
