using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlloCaramella : MonoBehaviour
{
    //variabile che contiene la schermata del minigioco delle caramelle
    public GameObject MinigiocoCaramelle;

    //variabile che contiene lo spawn delle caramelle
    public GameObject SpawnCaramelle;

    //variabile che contiene la schermata di game over
    public GameObject GameOver;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio riprodotto al game over: https://freesound.org/people/Absolutely_CrayCray/sounds/371205/
    Colonna sonora del minigioco corrente: https://freesound.org/people/LagMusics/sounds/662153/ */
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello; 
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*quando contro la deathbox impatta una caramella:
        1) Viene disattivato l'audio del livello
        2) Viene attivato l'audio di game over
        3) la scala temporale viene settata a zero
        4) la schermata di game over viene settata a vero
        5) la schermata del minigioco viene settata a falso*/

        if (col.gameObject.tag == "Caramella")
        {
            AudioLivello.Stop();
            AudioGameOver.Play();
            Time.timeScale = 0f;
            GameOver.SetActive(true);
            MinigiocoCaramelle.SetActive(false);
            SpawnCaramelle.SetActive(false);
        }
    }
}
