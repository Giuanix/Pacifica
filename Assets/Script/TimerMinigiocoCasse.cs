using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMinigiocoCasse : MonoBehaviour
{
    //variabile che contiene la barra del timer
    [SerializeField] private Image BarraTimerMinigiocoCassa;

    //variabili che contengono le schermate di game over e del minigioco
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject MinigiocoCasse;

    //variabile con il valore del timer del minigioco
    public float TimerMinigiocoCassa;

    //variabile con il valore massimo del timer del minigioco
    public float MaxTimerMinigiocoCassa;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio game over: https://freesound.org/people/Absolutely_CrayCray/sounds/371205/
    Audio minigioco delle casse di frutta: https://freesound.org/people/SkibkaMusic/sounds/541765/*/
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello;
    void Start()
    {
        Time.timeScale = 1f;
        GameOver.SetActive(false);
        MinigiocoCasse.SetActive(true);
        TimerMinigiocoCassa = MaxTimerMinigiocoCassa;
    }
    void Update()
    {
        TimerMinigiocoCassa -= Time.deltaTime;
        //viene applicata la variabile del timer alla barra nell'hud
        BarraTimerMinigiocoCassa.fillAmount =(float)TimerMinigiocoCassa/MaxTimerMinigiocoCassa;

        //quando il timer arriva a zero viene disattivato il minigioco e viene attivata la schermata di game over
        if(TimerMinigiocoCassa <= 0f)
        {
            TimerMinigiocoCassa = MaxTimerMinigiocoCassa;
            Time.timeScale = 0f;
            AudioLivello.Stop();
            AudioGameOver.Play();
            GameOver.SetActive(true);
            MinigiocoCasse.SetActive(false);
        }
    }
}
