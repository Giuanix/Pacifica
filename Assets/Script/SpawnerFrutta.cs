using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerFrutta : MonoBehaviour
{
    [SerializeField] private GameObject Mela;
    [SerializeField] private GameObject Pera;
    [SerializeField] private GameObject Banana;
    [SerializeField] private GameObject MelaGialla;
    [SerializeField] private GameObject BananaVerde;
    [SerializeField] private GameObject PeraRossa;
    [SerializeField] private float Radius = 1;
    private int LimiteRange = 4;
    [SerializeField] private int MaxContatoreAumentoDiff;
    private float RandomNum = 0;
    public bool AttivaProgressioneDiffUno = true;
    public bool AttivaProgressioneDiffDue = false;
    public Inventory ManagerInventario;
    public TimerMinigiocoCasse ManagerTimer;

    void Start()
    {
        if(ManagerInventario.MinigiocoCasse == true)
        {
            SpawnObjectRandom();
        }
    }

    void Update()
    {
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

        if(LimiteRange == 7)
        {
            AttivaProgressioneDiffUno = false;
            AttivaProgressioneDiffDue = true;
        }

        if(ManagerTimer.MaxTimerMinigiocoCassa == 20)
        {
            AttivaProgressioneDiffUno = false;
            AttivaProgressioneDiffDue = false;
        }
    }
    public void SpawnObjectRandom()
    {
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
