using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerFrutta : MonoBehaviour
{
    //variabili che contengono i frutti
    [SerializeField] private GameObject Mela;
    [SerializeField] private GameObject Pera;
    [SerializeField] private GameObject Banana;
    [SerializeField] private GameObject MelaGialla;
    [SerializeField] private GameObject BananaVerde;
    [SerializeField] private GameObject PeraRossa;

    //variabile che contiene il raggio di spawn
    [SerializeField] private float Radius = 1;

    //variabile che contiene il limite di raggio
    private int LimiteRange = 4;

    //variabile che contiene il contatore di difficolta
    [SerializeField] private int MaxContatoreAumentoDiff;

    //variabile che contiene il valore random
    private float RandomNum = 0;

    //variabili per l'attivazione della difficolta  di progressione 1 o 2
    public bool AttivaProgressioneDiffUno = true;
    public bool AttivaProgressioneDiffDue = false;

    //variabili manager che contengono l'inventario e il timer del minigioco
    public Inventory ManagerInventario;
    public TimerMinigiocoCasse ManagerTimer;

    void Start()
    {
        //fa spawnare gli oggetti
        if(ManagerInventario.MinigiocoCasse == true)
        {
            SpawnObjectRandom();
        }
    }

    void Update()
    {
        //funzione per il controllo della difficolta
        if(ManagerInventario.ContatoreAumentoDiff == MaxContatoreAumentoDiff)
        {
            if(AttivaProgressioneDiffUno == true)
            {
                Difficolta1();
            }
            else if(AttivaProgressioneDiffDue == true)
            {
                Difficolta2();
            }
        }

        //funzione di controllo per la modifica della difficolta
        if(LimiteRange == 7)
        {
            AttivaProgressioneDiffUno = false;
            AttivaProgressioneDiffDue = true;
        }

        if(ManagerTimer.MaxTimerMinigiocoCassa == 10)
        {
            AttivaProgressioneDiffUno = false;
            AttivaProgressioneDiffDue = false;
        }
    }
    public void SpawnObjectRandom()
    {
        //funzione di spawn random deglio oggetti
        for (int i = 0; i < ManagerInventario.TotNumeroFrutti; i++)
        {
            RandomNum = Random.Range(1,LimiteRange);
            Vector3 randomPos = Random.insideUnitCircle * Radius;
            if (RandomNum == 1)
            {
                Instantiate(Mela, randomPos, Quaternion.identity);
            }
            else if(RandomNum == 2)
            {
                Instantiate(Pera, randomPos, Quaternion.identity);
            }
            else if(RandomNum == 3)
            {
                Instantiate(Banana, randomPos, Quaternion.identity);
            }
            else if(RandomNum == 4)
            {
                Instantiate(BananaVerde, randomPos, Quaternion.identity);
            }
            else if(RandomNum == 5)
            {
                Instantiate(MelaGialla, randomPos, Quaternion.identity);
            }
            else if(RandomNum == 6)
            {
                Instantiate(PeraRossa, randomPos, Quaternion.identity);
            }
        }
    }

    //funzioni della diffiocoltà 1 e 2, in una aumenta il numero di frutti, nell'altro diminuisce il tempo a disposizione
    public void Difficolta1()
    {
        LimiteRange = LimiteRange + 1;
        MaxContatoreAumentoDiff = MaxContatoreAumentoDiff + 4;
    }

    public void Difficolta2()
    {
        ManagerTimer.MaxTimerMinigiocoCassa = ManagerTimer.MaxTimerMinigiocoCassa - 1;
        MaxContatoreAumentoDiff = MaxContatoreAumentoDiff + 2;
    }
}
