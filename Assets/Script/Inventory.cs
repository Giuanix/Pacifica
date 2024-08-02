using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //variabile che contiene i frutti
    public int NumeroFrutti;

    //variabile che contiene il totale dei frutti
    public int TotNumeroFrutti;

    //variabile che contiene la schermata del minigioco delle casse
    public GameObject MinigiocoCasse;

    //variabile che contiene il manager dello spawner dei frutti
    public SpawnerFrutta ManagerSpawner;

    //variabile che contiene il mamager del timer del minigioco 
    public TimerMinigiocoCasse ManagerTimer;

    //variabile che contiene il contatore dell'aumento di difficoltà
    public int ContatoreAumentoDiff;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio Passaggio dello stage: https://freesound.org/people/GameAudio/sounds/220173/ */
    [SerializeField] private AudioSource AudioPassaggioLivello;
    void Start()
    {
        //i valori del numero di frutti e il contatore di difficoltà vengono settati a zero
        NumeroFrutti = 0;
        ContatoreAumentoDiff = 0;
    }
    void Update()
    {
        //se il numero dei frutti è uguale al totale di frutti viene riprodotta la clip audio
        if(NumeroFrutti == TotNumeroFrutti)
        {
            AudioPassaggioLivello.Play();
        }
        
        //se il numero di frutti è uguale al totale dei frutti e la boleana di progressione della difficoltà 1 è vera esegui la funzione di progressione di difficoltà 1
        if (NumeroFrutti == TotNumeroFrutti && ManagerSpawner.AttivaProgressioneDiffUno == true)
        {
            FunzioneProgressioneDiffUno();
        }

        //se il numero di frutti è uguale al totale dei frutti e la boleana di progressione della difficoltà 2 è vera esegui la funzione di progressione di difficoltà 2
        else if (NumeroFrutti == TotNumeroFrutti && ManagerSpawner.AttivaProgressioneDiffDue == true)
        {
            FunzioneProgressioneDiffDue();
        }
    }

    /*la funzione di progressione di difficoltà uno:
    1) Aumenta il totale di frutti di 1
    2) Aumenta il contatore di difficoltà di 1
    3) Richiama la funzione di spawn degli oggetti
    4) Resetta il timer del minigioco al massimo
    5) Resetta il numero di frutti a 0*/
    public void FunzioneProgressioneDiffUno()
    {
        TotNumeroFrutti = TotNumeroFrutti + 1;
        ContatoreAumentoDiff = ContatoreAumentoDiff + 1;
        ManagerSpawner.SpawnObjectRandom();
        ManagerTimer.TimerMinigiocoCassa = ManagerTimer.MaxTimerMinigiocoCassa;
        NumeroFrutti = 0;
    }

    /*la funzione di progressione di difficoltà due:
    2) Aumenta il contatore di difficoltà di 1
    3) Richiama la funzione di spawn degli oggetti
    4) Resetta il timer del minigioco al massimo
    5) Resetta il numero di frutti a 0*/
    public void FunzioneProgressioneDiffDue()
    {
        ContatoreAumentoDiff = ContatoreAumentoDiff + 1;
        ManagerSpawner.SpawnObjectRandom();
        ManagerTimer.TimerMinigiocoCassa = ManagerTimer.MaxTimerMinigiocoCassa;
        NumeroFrutti = 0;
    }
}
