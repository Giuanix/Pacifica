using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int NumeroFrutti;
    public GameObject MinigiocoCasse;
    [SerializeField] private int TotNumeroFrutti;

    void Start()
    {
        NumeroFrutti = 0;
        MinigiocoCasse.SetActive(true);
    }
    void Update()
    {
        if (NumeroFrutti == TotNumeroFrutti)
        {
            MinigiocoCasse.SetActive(false);
        }  
    }
}
