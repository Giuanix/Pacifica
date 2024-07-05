using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int NumeroFrutti;
    [SerializeField] private int TotNumeroFrutti;
    void Update()
    {
        if (NumeroFrutti == TotNumeroFrutti);
        {
            Debug.Log("LIVELLO COMPLETATO");
        }  
    }
}
