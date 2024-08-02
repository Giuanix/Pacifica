using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PgcaramelleMovement : MonoBehaviour
{
    private bool isBeingHeld = false;
    public GameObject MinigiocoCaramelle;
    public GameObject SpawnCaramelle;
    public GameObject GameOver;
    public GameObject x2;
    private bool PowerUp = false;
    public float MaxPowerUpTimer;
    private float PowerUpTimer;
    public ScoreCaramelle Manager;
    [SerializeField] private float IncrementoScore;
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello;
    [SerializeField] private AudioSource AudioMorso;
    [SerializeField] private AudioSource AudioPowerUp;
    void Start()
    {
        Time.timeScale = 1f;
        MinigiocoCaramelle.SetActive(true);
        SpawnCaramelle.SetActive(true);
        GameOver.SetActive(false);
    }
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }

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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Caramella")
        {
            AudioMorso.Play();
            Manager.TotScore = Manager.TotScore + IncrementoScore;
            GestioneProgressione.ValoreAttualeProgressione = GestioneProgressione.ValoreAttualeProgressione + 1;
            PlayerPrefs.SetFloat("Progressi", GestioneProgressione.ValoreAttualeProgressione);
        }
        else if(col.gameObject.tag == "Peperoncino")
        {
            AudioLivello.Stop();
            AudioGameOver.Play();
            Time.timeScale = 0f;
            MinigiocoCaramelle.SetActive(false);
            SpawnCaramelle.SetActive(false);
            GameOver.SetActive(true);
        }
        else if(col.gameObject.tag == "PowerUp")
        {
            AudioPowerUp.Play();
            IncrementoScore = IncrementoScore + 1;
            PowerUpTimer = MaxPowerUpTimer;
            PowerUp = true;
            x2.SetActive(true);
        }
    }
    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
