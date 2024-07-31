using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject MenuPausa;
    [SerializeField] private AudioSource BottonClic;
    void Start()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
    }
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
