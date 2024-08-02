using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GestioneProgressione : MonoBehaviour
{
    /*Le seguenti variabili contengono:
    1) Sprite del minigioco delle caramelle attivo
    2) Sprite del minigioco delle caramelle inattivo
    3) Sprite del minigioco del ping pong attivo
    4) Sprite del minigioco del ping pong inattivo*/
    [SerializeField] private Sprite SpriteMinigiocoCaramelleOn;
    [SerializeField] private Sprite SpriteMinigiocoCaramelleOff;
    [SerializeField] private Sprite SpriteMinigiocoPingPongOn;
    [SerializeField] private Sprite SpriteMinigiocoPingPongOff;

    //variabili contenenti il riferimento ai pulsanti dei bottoni
    [SerializeField] private Button PulsanteMinigiocoCaramelle;
    [SerializeField] private Button PulsanteMinigiocoPingPong;

    //variabili contenenti le 2 schermate che avvisano dello sblocco del minigioco
    [SerializeField] private GameObject SchermataSblocco1;
    [SerializeField] private GameObject SchermataSblocco2;

    // variabili che servono per il controllo di attivazione e disattivazione delle shcermate sopra citate
    [SerializeField] private bool AttivaSchermata1 = false;
    [SerializeField] private bool AttivaSchermata2 = false;

    //variabile contenente lo slider della barra di progressione
    [SerializeField] private Slider BarraProgressione;

    //variabile statica che fa riferimento al valore attuale di progressione
    public static float ValoreAttualeProgressione;

    //variabile che fa riferimento al valore attuale di progressione
    public float ValoreSbloccoAttuale;

    //variabili che contengono i valori necessari per lo sblocco dei minigiochi
    [SerializeField] private float ValoreSblocco1;
    [SerializeField] private float ValoreSblocco2;

    
    void Awake()
    {
        //settiamo le schermate di sblocco a falso
        SchermataSblocco1.SetActive(false);
        SchermataSblocco2.SetActive(false);

        //carichiamo l'ultimo valore di progressione
        if (PlayerPrefs.HasKey("Progressi") && PlayerPrefs.GetFloat("Progressi") > 0)
        {
            LoadProgress();
        }

        /*funzione che gestisce lo sblocco del primo minigioco:
        1) Assegnamo lo sprite di minigioco attivato
        2) Attiviamo le funzioni del bottone
        3) Il valore di progressione minimo diventa il valore di sblocco 1
        4) Il valore di progressione massimo diventa il valore di sblocco 2*/
        if (ValoreAttualeProgressione >= ValoreSblocco1)
        {
            PulsanteMinigiocoCaramelle.image.sprite = SpriteMinigiocoCaramelleOn;
            PulsanteMinigiocoCaramelle.enabled = true;
            BarraProgressione.minValue = ValoreSblocco1;
            BarraProgressione.maxValue = ValoreSblocco2;
        }

        /*Se i requisiti non vengono soddisfatti:
        1) Assegnamo lo sprite di minigioco disattivato
        2) Disattiviamo le funzioni del bottone
        3) Il valore di progressione minimo diventa 0
        4) Il valore di progressione massimo diventa il valore di sblocco 1*/
        else
        {
            PulsanteMinigiocoCaramelle.image.sprite = SpriteMinigiocoCaramelleOff;
            PulsanteMinigiocoCaramelle.enabled = false;
            BarraProgressione.minValue = 0;
            BarraProgressione.maxValue = ValoreSblocco1;
        }

        /*funzione che gestisce lo sblocco del secondo minigioco:
        1) Assegnamo lo sprite di minigioco attivato
        2) Attiviamo le funzioni del bottone*/
        if (ValoreAttualeProgressione >= ValoreSblocco2)
        {
            PulsanteMinigiocoPingPong.image.sprite = SpriteMinigiocoPingPongOn;
            PulsanteMinigiocoPingPong.enabled = true;
        }

        /*Se i requisiti non vengono soddisfatti:
        1) Assegnamo lo sprite di minigioco disattivato
        2) Disattiviamo le funzioni del bottone*/
        else
        {
            PulsanteMinigiocoPingPong.image.sprite = SpriteMinigiocoPingPongOff;
            PulsanteMinigiocoPingPong.enabled = false;
        }
    }
    void Start()
    {
        //Se il valore Attuale di progressione è minore del valore di sblocco 1 il valore attuale diventa uguale a quello del valore di sblocco 1
        if (ValoreAttualeProgressione <= ValoreSblocco1)
        {
            ValoreSbloccoAttuale = ValoreSblocco1;
        }

        //Se il valore Attuale di progressione è minore del valore di sblocco 2 e maggiore del valore di sblocco 1 il valore attuale diventa uguale a quello del valore di sblocco 2
        else if (ValoreAttualeProgressione <= ValoreSblocco2 && ValoreAttualeProgressione >= ValoreSblocco1)
        {
            ValoreSbloccoAttuale = ValoreSblocco2;
        }

        //assegnamo il valore di progressione allo slider
        BarraProgressione.value = ValoreAttualeProgressione;  
    }

    private void Update()
    {
        /*se il valore di progressione è >= al valore di sblocco 1 e AttivaSchermata è unguale a falso:
        1) Si attiva la schermata di sblocco
        2) Attiva schermata 1 si setta a vero
        3) Salviamo il valore della boleana*/

        if (ValoreAttualeProgressione >= ValoreSblocco1 && AttivaSchermata1 == false)
        {
            SchermataSblocco1.SetActive(true);
            AttivaSchermata1 = true;
            PlayerPrefs.SetInt("AttivaSchermata1", 1);
        }

        /*se il valore di progressione è >= al valore di sblocco 2 e AttivaSchermata è unguale a falso:
        1) Si attiva la schermata di sblocco
        2) Attiva schermata 2 si setta a vero
        3) Salviamo il valore della boleana*/
        if (ValoreAttualeProgressione >= ValoreSblocco2 && AttivaSchermata2 == false)
        { 
            SchermataSblocco2.SetActive(true);
            AttivaSchermata2 = true;
            PlayerPrefs.SetInt("AttivaSchermata2", 1);
        }
    }

    //funzione che gestisce il caricamento dei progressi
    public void LoadProgress()
    {
        ValoreAttualeProgressione = PlayerPrefs.GetFloat("Progressi", 0);

        if(PlayerPrefs.GetInt("AttivaSchermata1") == 1)
        {
            AttivaSchermata1 = true;
        }
        if (PlayerPrefs.GetInt("AttivaSchermata2") == 1)
        {
            AttivaSchermata2 = true;
        }
    }
}
