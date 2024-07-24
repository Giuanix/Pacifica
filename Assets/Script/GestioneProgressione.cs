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

    [SerializeField] private Slider BarraProgressione;
    public static float ValoreAttualeProgressione;
    [SerializeField] private float ValoreSbloccoAttuale;
    [SerializeField] private float ValoreSblocco1;
    [SerializeField] private float ValoreSblocco2;

    
    void Awake()
    {
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
        PlayerPrefs.SetFloat("Progressi", ValoreAttualeProgressione);
    }

    public void LoadProgress()
    {
        ValoreAttualeProgressione = PlayerPrefs.GetFloat("Progressi", 0);
    }
}
