using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GestioneProgressione : MonoBehaviour
{
    [SerializeField] private Sprite SpriteMinigiocoCaramelleOn;
    [SerializeField] private Sprite SpriteMinigiocoCaramelleOff;
    [SerializeField] private Sprite SpriteMinigiocoPingPongOn;
    [SerializeField] private Sprite SpriteMinigiocoPingPongOff;
    [SerializeField] private Button PulsanteMinigiocoCaramelle;
    [SerializeField] private Button PulsanteMinigiocoPingPong;
    [SerializeField] private GameObject SchermataSblocco1;
    [SerializeField] private GameObject SchermataSblocco2;
    [SerializeField] private bool AttivaSchermata1 = false;
    [SerializeField] private bool AttivaSchermata2 = false;
    [SerializeField] private Slider BarraProgressione;
    public static float ValoreAttualeProgressione;
    public float ValoreSbloccoAttuale;
    [SerializeField] private float ValoreSblocco1;
    [SerializeField] private float ValoreSblocco2;

    
    void Awake()
    {
        SchermataSblocco1.SetActive(false);
        SchermataSblocco2.SetActive(false);

        if (PlayerPrefs.HasKey("Progressi") && PlayerPrefs.GetFloat("Progressi") > 0)
        {
            LoadProgress();
        }
        if (ValoreAttualeProgressione >= ValoreSblocco1)
        {
            PulsanteMinigiocoCaramelle.image.sprite = SpriteMinigiocoCaramelleOn;
            PulsanteMinigiocoCaramelle.enabled = true;
            BarraProgressione.minValue = ValoreSblocco1;
            BarraProgressione.maxValue = ValoreSblocco2;
        }
        else
        {
            PulsanteMinigiocoCaramelle.image.sprite = SpriteMinigiocoCaramelleOff;
            PulsanteMinigiocoCaramelle.enabled = false;
            BarraProgressione.minValue = 0;
            BarraProgressione.maxValue = ValoreSblocco1;
        }

        if (ValoreAttualeProgressione >= ValoreSblocco2)
        {
            PulsanteMinigiocoPingPong.image.sprite = SpriteMinigiocoPingPongOn;
            PulsanteMinigiocoPingPong.enabled = true;

            if (AttivaSchermata2 == false)
            {
                SchermataSblocco2.SetActive(true);
                AttivaSchermata2 = true;
            }
        }
        else
        {
            PulsanteMinigiocoPingPong.image.sprite = SpriteMinigiocoPingPongOff;
            PulsanteMinigiocoPingPong.enabled = false;
        }
    }
    void Start()
    {
        if (ValoreAttualeProgressione <= ValoreSblocco1)
        {
            ValoreSbloccoAttuale = ValoreSblocco1;
        }
        else if (ValoreAttualeProgressione <= ValoreSblocco2 && ValoreAttualeProgressione >= ValoreSblocco1)
        {
            ValoreSbloccoAttuale = ValoreSblocco2;
        }
        BarraProgressione.value = ValoreAttualeProgressione;  
    }

    private void Update()
    {
        if (ValoreAttualeProgressione >= ValoreSblocco1 && AttivaSchermata1 == false)
        {
            SchermataSblocco1.SetActive(true);
            AttivaSchermata1 = true;
            PlayerPrefs.SetInt("AttivaSchermata1", 1);
        }

        if (ValoreAttualeProgressione >= ValoreSblocco2)
        { 
            if (AttivaSchermata2 == false)
            {
                SchermataSblocco2.SetActive(true);
                AttivaSchermata2 = true;
                PlayerPrefs.SetInt("AttivaSchermata2", 1);
            }
        }
    }
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
