using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausa : MonoBehaviour
{
    //variabile che contiene la schermata di pausa
    [SerializeField] private GameObject MenuPausa;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio click del bottone: https://freesound.org/people/javieralejp2/sounds/658594/ */
    [SerializeField] private AudioSource BottonClic;
    void Start()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    /*le funzioni seguenti geastiscono i pulsanti presenti nella pausa:
    il nome della funzione descrive l'azione da essa compiuta o il menu a cui fa riferimento*/
    public void MettiInPausa()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        BottonClic.Play();
    }
    public void Riprendi()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
        BottonClic.Play();
    }
    public void MenuPrincipale()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        BottonClic.Play();
    }
}
