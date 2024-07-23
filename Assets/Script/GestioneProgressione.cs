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
    [SerializeField] private float ValoreAttualeProgressione;
    [SerializeField] private float ValoreSblocco1;
    [SerializeField] private float ValoreSblocco2;
    void Start()
    {
        if(ValoreAttualeProgressione >=ValoreSblocco1)
        {
            PulsanteMinigiocoCaramelle.image.sprite = SpriteMinigiocoCaramelleOn;
            PulsanteMinigiocoCaramelle.enabled = true;
        }
        else
        {
            PulsanteMinigiocoCaramelle.image.sprite = SpriteMinigiocoCaramelleOff;
            PulsanteMinigiocoCaramelle.enabled = false;
        }

        if(ValoreAttualeProgressione >=ValoreSblocco2)
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
}
