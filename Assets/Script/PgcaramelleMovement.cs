using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PgcaramelleMovement : MonoBehaviour
{
    //variabile che tine traccia se vi è un tocco o no sullo schermo
    private bool isBeingHeld = false;

    //variabili che contengono le schermate di game over e del minigioco corrente
    public GameObject MinigiocoCaramelle;
    public GameObject GameOver;

    //variabile che contiene lo spawn delle caramelle
    public GameObject SpawnCaramelle;

    //variabile che contiene il componente estetico su schermo "x2"
    public GameObject x2;

    //variabile che tiene traccia se il power up è attivo o meno
    private bool PowerUp = false;

    //variabile che segna il tempo massimo di attivazione del power up
    public float MaxPowerUpTimer;

    //variabile che segna il tempo di attivazione del power up
    private float PowerUpTimer;

    //variabile che contiene il manager che gestisce lo score
    public ScoreCaramelle Manager;

    //varibile che aumenta lo score acquisito di 1 con il power up
    [SerializeField] private float IncrementoScore;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio del Game Over: https://freesound.org/people/Absolutely_CrayCray/sounds/371205/
    Audio del minigioco delle caramelle: https://freesound.org/people/LagMusics/sounds/662153/
    Audio del morso del player: https://freesound.org/people/watsnick/sounds/423479/
    Audio del power up: https://freesound.org/people/Romeo_Kaleikau/sounds/588251/? */
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello;
    [SerializeField] private AudioSource AudioMorso;
    [SerializeField] private AudioSource AudioPowerUp;
    void Start()
    {
        /*Nello start:
        1) la scala temporale viene settata a 1
        2) il minigioco viene settato a vero
        3) lo spawner delle caramelle viene settato a vero
        4) la schermata di game over viene settato a falso*/
        Time.timeScale = 1f;
        MinigiocoCaramelle.SetActive(true);
        SpawnCaramelle.SetActive(true);
        GameOver.SetActive(false);
    }
    void Update()
    {
        /*se il tocco avviene
        1) viene creato un vector 3 di nome mousePos
        2) la posizione del mousePos è uguale al punto toccato sullo schermo
        3) tale punto deve essere nel punto inquadrato dalla camera
        4) l'oggetto toccato avrà la stessa position di quella che tocchiamo su schermo */
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }

        /*se power up diventa vero:
        1) il timer inizia a decrementare
        2) quando il timer diventa zero il power up si disattiva*/
        if(PowerUp == true)
        {
            PowerUpTimer = PowerUpTimer - Time.deltaTime;
            if(PowerUpTimer <= 0)
            {
                IncrementoScore = IncrementoScore - 1;
                PowerUp = false;
                x2.SetActive(false);
            }
        }
    }
    private void OnMouseDown()
    {
        //quando un oggetto viene cliccato la sua posizione diventerà unguale a quella del punto toccato...
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }
    private void OnMouseUp()
    {
        //...fino a quando non viene rilasciato
        isBeingHeld = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        /*se la caramella collide con il player:
        1) l'audio viene riprodotto
        2) aumenta lo score
        3) Aumenta il valore di progressione dello sblocco dei minigiochi
        4) setta il valore di progressione*/
        if(col.gameObject.tag == "Caramella")
        {
            AudioMorso.Play();
            Manager.TotScore = Manager.TotScore + IncrementoScore;
            GestioneProgressione.ValoreAttualeProgressione = GestioneProgressione.ValoreAttualeProgressione + 1;
            PlayerPrefs.SetFloat("Progressi", GestioneProgressione.ValoreAttualeProgressione);
        }

        /*se il peperoncino collide con il player:
        1) l'audio del livello viene interrotto e viene riprodotto quello di game over
        2) la scala temporale viene settata a 0
        3) viene disattivata la schermata del minigioco e lo spawn delle caramelle
        4) viene attivata la schermata di game over*/
        else if (col.gameObject.tag == "Peperoncino")
        {
            AudioLivello.Stop();
            AudioGameOver.Play();
            Time.timeScale = 0f;
            MinigiocoCaramelle.SetActive(false);
            SpawnCaramelle.SetActive(false);
            GameOver.SetActive(true);
        }

        /*se il power Up collide con il player:
        1) viene riprodotto l'audio del power up
        2) viene applicato l'incremetno di score
        3) il power up viene attivato
        4) viene attivata la componente estetica "x2" */
        else if (col.gameObject.tag == "PowerUp")
        {
            AudioPowerUp.Play();
            IncrementoScore = IncrementoScore + 1;
            PowerUpTimer = MaxPowerUpTimer;
            PowerUp = true;
            x2.SetActive(true);
        }
    }
}
