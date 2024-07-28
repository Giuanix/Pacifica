using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipale : MonoBehaviour
{
    [SerializeField] private GameObject MenuIniziale;
    [SerializeField] private GameObject MenuOpzioni;
    [SerializeField] private GameObject MenuScore;
    [SerializeField] private GameObject MenuSceltaGioco;
    [SerializeField] private GameObject MinigiocoCassa;
    [SerializeField] private GameObject MinigiocoCaramelle;
    [SerializeField] private GameObject MinigiocoPingPong;
    [SerializeField] private AudioSource ClicBotton;
    public void Gioca()
    {
        MenuIniziale.SetActive(false);
        MenuSceltaGioco.SetActive(true);
        ClicBotton.Play();
    }

    public void Opzioni()
    {
        MenuIniziale.SetActive(false);
        MenuOpzioni.SetActive(true);
        ClicBotton.Play();
    }

    public void RecordScore()
    {
        MenuIniziale.SetActive(false);
        MenuScore.SetActive(true);
        ClicBotton.Play();
    }

    public void Indietro()
    {
        MenuIniziale.SetActive(true);
        MenuSceltaGioco.SetActive(false);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
        MinigiocoCassa.SetActive(false);
        MinigiocoCaramelle.SetActive(false);
        MinigiocoPingPong.SetActive(false);
        ClicBotton.Play();
    }
    public void SchermataMinigiocoCasse()
    {
        MinigiocoCassa.SetActive(true);
        ClicBotton.Play();
    }
    public void CloseSchermataMinigiocoCasse()
    {
        MinigiocoCassa.SetActive(false);
        ClicBotton.Play();
    }
    public void SchermataMinigiocoPingPong()
    {
        MinigiocoPingPong.SetActive(true);
        ClicBotton.Play();
    }
    public void CloseSchermataMinigiocoPingPong()
    {
        MinigiocoPingPong.SetActive(false);
        ClicBotton.Play();
    }
    public void SchermataMinigiocoCaramelle()
    {
        MinigiocoCaramelle.SetActive(true);
        ClicBotton.Play();
    }
    public void CloseSchermataMinigiocoCaramelle()
    {
        MinigiocoCaramelle.SetActive(false);
        ClicBotton.Play();
    }
    public void PlayMinigiocoCasse()
    {
        SceneManager.LoadScene(3);
        MenuIniziale.SetActive(false);
        MinigiocoCassa.SetActive(false);
        MenuSceltaGioco.SetActive(true);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
        Time.timeScale = 1f;
        ClicBotton.Play();
    }
    public void PlayMinigiocoCaramelle()
    {
        SceneManager.LoadScene(2);
        MenuIniziale.SetActive(false);
        MinigiocoCaramelle.SetActive(false);
        MenuSceltaGioco.SetActive(true);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
        Time.timeScale = 1f;
        ClicBotton.Play();
    }
    public void PlayMinigiocoPingPong()
    {
        SceneManager.LoadScene(1);
        MenuIniziale.SetActive(false);
        MinigiocoPingPong.SetActive(false);
        MenuSceltaGioco.SetActive(true);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
        Time.timeScale = 1f;
        ClicBotton.Play();
    }
    public void Esci()
    {
        Application.Quit();
    }
}
