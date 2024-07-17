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

    public void Gioca()
    {
        MenuIniziale.SetActive(false);
        MenuSceltaGioco.SetActive(true);
    }

    public void Opzioni()
    {
        MenuIniziale.SetActive(false);
        MenuOpzioni.SetActive(true);
    }

    public void RecordScore()
    {
        MenuIniziale.SetActive(false);
        MenuScore.SetActive(true);
    }

    public void Indietro()
    {
        MenuIniziale.SetActive(true);
        MenuSceltaGioco.SetActive(false);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
    }

    public void MinigiocoCasse()
    {
        SceneManager.LoadScene(3);
        MenuIniziale.SetActive(true);
        MenuSceltaGioco.SetActive(false);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MinigiocoPingPong()
    {
        SceneManager.LoadScene(1);
        MenuIniziale.SetActive(true);
        MenuSceltaGioco.SetActive(false);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MinigiocoCaramelle()
    {
        SceneManager.LoadScene(2);
        MenuIniziale.SetActive(true);
        MenuSceltaGioco.SetActive(false);
        MenuOpzioni.SetActive(false);
        MenuScore.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Esci()
    {
        Application.Quit();
    }
}
