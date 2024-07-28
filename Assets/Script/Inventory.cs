using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int NumeroFrutti;
    public int TotNumeroFrutti;
    public GameObject MinigiocoCasse;
    public SpawnerFrutta ManagerSpawner;
    public TimerMinigiocoCasse ManagerTimer;
    public int ContatoreAumentoDiff;
    [SerializeField] private AudioSource AudioPassaggioLivello;
    void Start()
    {
        NumeroFrutti = 0;
        ContatoreAumentoDiff = 0;
    }
    void Update()
    {
        if(NumeroFrutti == TotNumeroFrutti)
        {
            AudioPassaggioLivello.Play();
        }
        
        if (NumeroFrutti == TotNumeroFrutti && ManagerSpawner.AttivaProgressioneDiffUno == true)
        {
            FunzioneProgressioneDiffUno();
        }
        else if (NumeroFrutti == TotNumeroFrutti && ManagerSpawner.AttivaProgressioneDiffDue == true)
        {
            FunzioneProgressioneDiffDue();
        }
    }

    public void FunzioneProgressioneDiffUno()
    {
        TotNumeroFrutti = TotNumeroFrutti + 1;
        ContatoreAumentoDiff = ContatoreAumentoDiff + 1;
        ManagerSpawner.SpawnObjectRandom();
        ManagerTimer.TimerMinigiocoCassa = ManagerTimer.MaxTimerMinigiocoCassa;
        NumeroFrutti = 0;
    }

    public void FunzioneProgressioneDiffDue()
    {
        ContatoreAumentoDiff = ContatoreAumentoDiff + 1;
        ManagerSpawner.SpawnObjectRandom();
        ManagerTimer.TimerMinigiocoCassa = ManagerTimer.MaxTimerMinigiocoCassa;
        NumeroFrutti = 0;
    }
}
