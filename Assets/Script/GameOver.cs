using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio del click del bottone: https://freesound.org/people/javieralejp2/sounds/658594/ */
    [SerializeField] private AudioSource BottonClic;

    //funzione per la gestione del pulsante di ritorno al menu
    public void TornaAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        BottonClic.Play();
    }
}
