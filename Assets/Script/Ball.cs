using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //variabile contenente la schermata di game over
    [SerializeField] private GameObject GameOver;

    //variabile contenente il minigioco in gestione
    [SerializeField] private GameObject MinigiocoPingPong;

    //variabile contenente la velocita della palla
    [SerializeField] private float Speed;

    //variabile contenente il rigidbody della palla
    [SerializeField] private Rigidbody2D rb;

    //variablie contenente il player
    [SerializeField] private GameObject Pg;

    //variabile contenente un contatore che tiene traccia di quante volte è diminuita la dimensione del player
    [SerializeField] private float ContatoreDiminuisciPlayer = 0;

    //variabile contenente una booleana con il compito di disattivare l'aumento della velocità della palla
    private bool AumentoSpeed = true;

    //variabile contenente una booleana con il compito di disattivare la  diminuizione di dimensione del player
    private bool DiminuisciPlayer = false;

    //variabili contenenti i valori delle assi x e y
    private float x;
    private float y;

    //Variabile contente la dimensione del player
    [SerializeField] private float DimensioneX = 1.5f;

    //variabile contenente il manager dello score
    public ScorePingPong Manager;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio riprodotto al game over: https://freesound.org/people/Absolutely_CrayCray/sounds/371205/
    Colonna sonora del minigioco corrente: https://freesound.org/people/Mrthenoronha/sounds/513667/
    Audio del rumore emesso dall'impatto della palla: https://freesound.org/people/ToastHatter/sounds/514989/ */
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello;
    [SerializeField] private AudioSource AudioPalla;
    void Start()
    {
        /*all'avvio del gioco verranno eseguite queste azioni:
        1) la scala temporale verrà settata a 1
        2) il mingioco verrà reso visibile a schermo
        3) la schermata di game over verrà settata a falso
        4) verrà eseguita la funzione "Launch" che provvederà ad eseguire il primo lancio della pallina*/
        Time.timeScale = 1f;
        MinigiocoPingPong.SetActive(true);
        GameOver.SetActive(false);
        Launch();
    }
    private void Update()
    {
        /*se il valore di velocità della palla diventa uguale a 13: 
        1) la variabile di controllo dell'aumento della velocità verrà settata a falso
        2) la variabile di controllo della diminuizione del player viene settata a vero*/
        if(Speed == 13f)
        {
            AumentoSpeed = false;
            DiminuisciPlayer = true;
        }

        /*se il contatore di diminuizione del player arriva a valore 5: 
        1) la variabile di controllo dell'aumento della velocità verrà settata a falso
        2) la variabile di controllo della diminuizione del player viene settata a falso*/
        if(ContatoreDiminuisciPlayer == 5)
        {
            AumentoSpeed = false;
            DiminuisciPlayer = false;
        }
    }
    /*funzione che esegue il lancio della palla allo start:
    1) viene decisa una direzione random sull'asse x e sull'asse y
    2) viene impressa una velocità alla palla sulla direzione scelta*/
    private void Launch()
    {
        x = Random.Range(0,2) == 0 ? -1 : 1;
        y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(Speed * x, Speed * y);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //riproduzione della clip di impatto quando la palla collide con un oggetto
        AudioPalla.Play();
        
        /*se la palla collide con il player:
        1) Aumenta lo score
        2) Aumenta il valore di progressione per lo sblocco dei successivi minigiochi
        3) Salva il punteggio di progressione*/
        if(col.gameObject.tag == "Player")
        {
            Manager.TotScore = Manager.TotScore + 1;
            GestioneProgressione.ValoreAttualeProgressione = GestioneProgressione.ValoreAttualeProgressione + 1;
            PlayerPrefs.SetFloat("Progressi", GestioneProgressione.ValoreAttualeProgressione);
        }

        /*se la palla collide con il player e AumentoSpeed è settata a vero:
        1) Aumenta il valore della velocità di 0.5
        2) Viene applicato questo valore alla velocità del rigidbody della palla*/
        if (col.gameObject.tag == "Player" && AumentoSpeed == true)
        {
            Speed = Speed + 0.5f;
            rb.velocity = new Vector2(Speed + x, Speed + y);
        }

        /*se la palla collide con il player e DiminuisciPlayer è settato a vero:
        1) diminuisce la dimensione del player di 0.1f
        2) applica il valore alla dimensione del player
        3) aumenta il contatore di controllo*/
        if (col.gameObject.tag == "Player" && DiminuisciPlayer == true)
        {
            DimensioneX = DimensioneX - 0.1f;
            Pg.transform.localScale = new Vector3(DimensioneX, 0.4f, 0);
            ContatoreDiminuisciPlayer = ContatoreDiminuisciPlayer + 1;
        }

        /*se la palla collide con la destroybox
        1) viene disattivato l'audio del livello
        2) viene attivato l'audio di game over
        3) viene settata la scala temporale a 0
        4) viene settata la schermata del minigioco a falso
        5) viene settata la schermata di game over a vero*/
        if (col.gameObject.tag == "DestroyBox")
        {
            AudioLivello.Stop();
            AudioGameOver.Play();
            Time.timeScale = 0f;
            MinigiocoPingPong.SetActive(false);
            GameOver.SetActive(true);
        }
    }
}
