using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int NumeroFrutti;
    public int TotNumeroFrutti;
    public GameObject MinigiocoCasse;
    public SpawnerFrutta Manager;
    void Start()
    {
        NumeroFrutti = 0;
    }
    void Update()
    {
        if (NumeroFrutti == TotNumeroFrutti)
        {
            TotNumeroFrutti = TotNumeroFrutti + 1;
            Manager.SpawnObjectRandom();
            NumeroFrutti = 0;
        }  
    }
}
