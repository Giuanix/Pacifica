using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indietro : MonoBehaviour
{
    //variabili che contengono le 2 schermate di sblocco del minigioco
    [SerializeField] private GameObject Schermata1;
    [SerializeField] private GameObject Schermata2;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio click del bottone: https://freesound.org/people/javieralejp2/sounds/658594/ */
    [SerializeField] private AudioSource BottonClic;

    //funzione che disattiva le schermate al click del bottone
    public void TornaIndietro()
    {
        Schermata1.SetActive(false);
        Schermata2.SetActive(false);
        BottonClic.Play();
    }
}
